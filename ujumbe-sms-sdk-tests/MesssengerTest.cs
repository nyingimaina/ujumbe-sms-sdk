using UjumbeSmsSdk;
using UjumbeSmsSdk.Request;

namespace UjumbeSmsSdkTests
{
    public class MesssengerTest
    {
        [Theory]
        [InlineData("254721553229", "MTkxMTI5NTEwNGRhNjk1ODc3N2E2ZWVmZTk3YWVk", "FUA MART", "nyingimaina@gmail.com")]
        public async Task MessegeSenderIntegrationTest(string phoneNumber, string apiKey, string senderId, string email)
        {

            //         {
            //             "Authorization": {
            //                 "ApiKey": "MTkxMTI5NTEwNGRhNjk1ODc3N2E2ZWVmZTk3YWVk",
            // "YourEmail": "nyingimaina@gmail.com"
            //             }
            //         }

            var messenger = new Messenger();
            var response = await messenger.SendSingleMessageAsync(
                new MessageBag
                {
                    Message = $"Hello World!  {DateTime.Now.ToLongDateString()} at {DateTime.Now.ToLongTimeString()}",
                    PhoneNumbers = new HashSet<string> { phoneNumber },
                    SenderId = senderId,
                },
                new Authorization
                {
                    ApiKey = apiKey,
                    YourEmail = email,
                },
                onResponse: async (response) =>
                {
                    var contentd = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode == false)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        throw new Exception(content);
                    }
                }
            );

            Assert.True(response.Success);
        }
    }
}