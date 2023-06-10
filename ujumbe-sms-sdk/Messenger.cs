using System.Text;
using System.Text.Json;
using UjumbeSmsSdk.Request;
using UjumbeSmsSdk.Response;

namespace UjumbeSmsSdk
{
    /// <summary>
    /// Represents a messenger for sending SMS messages using the Ujumbe SMS API.
    /// </summary>
    public class Messenger
    {
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="Messenger"/> class.
        /// </summary>
        public Messenger()
        {
            this.httpClient = new HttpClient();
        }

        /// <summary>
        /// Sends a single message using the Ujumbe SMS API.
        /// </summary>
        /// <param name="messageBag">The message bag containing the message details.</param>
        /// <param name="authorization">The authorization details for accessing the Ujumbe SMS API.</param>
        /// <param name="url">The URL of the messaging API endpoint.</param>
        /// <param name="onResponse">An optional callback function to handle the response. You may leave this null if you don't need to inspect the raw Http response.</param>
        /// <param name="countryCode">The country code to prepend to the phone numbers (optional).</param>
        /// <returns>The Ujumbe response object.</returns>
        public async Task<UjumbeResponse> SendSingleMessageAsync(
            MessageBag messageBag,
            Authorization authorization,
            string url = "https://ujumbesms.co.ke/api/messaging",
            Action<HttpResponseMessage>? onResponse = null,
            int? countryCode = null)
        {
            return await SendMultipleMessagesAsync(
                new List<MessageBag> { messageBag },
                authorization,
                url,
                onResponse,
                countryCode);
        }

        /// <summary>
        /// Sends multiple messages using the Ujumbe SMS API.
        /// </summary>
        /// <param name="messageBags">The list of message bags containing the message details.</param>
        /// <param name="authorization">The authorization details for accessing the Ujumbe SMS API.</param>
        /// <param name="url">The URL of the messaging API endpoint.</param>
        /// <param name="onResponse">An optional callback function to handle the response. You may leave this null if you don't need to inspect the raw Http response.</param>
        /// <param name="countryCode">The country code to prepend to the phone numbers (optional).</param>
        /// <returns>The Ujumbe response object.</returns>
        public async Task<UjumbeResponse> SendMultipleMessagesAsync(
            List<MessageBag> messageBags,
            Authorization authorization,
            string url = "https://ujumbesms.co.ke/api/messaging",
            Action<HttpResponseMessage>? onResponse = null,
            int? countryCode = null)
        {
            var phoneNumberFormatter = new PhoneNumberFormatter();
            var data = new
            {
                data = messageBags.Select((messageBag) =>
                {
                    var phoneNumbers = messageBag.PhoneNumbers.ToList();


                    for (int i = 0; i < phoneNumbers.Count; i++)
                    {
                        phoneNumbers[i] = phoneNumberFormatter.FormatPhoneNumber(phoneNumbers[i], countryCode);
                    };
                    messageBag.PhoneNumbers = phoneNumbers.ToHashSet();
                    return new
                    {

                        messageBag = messageBag
                    };
                })
            };
            string jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = content;
            request.Headers.Add("X-Authorization", authorization.ApiKey);
            request.Headers.Add("Email", authorization.YourEmail);

            HttpResponseMessage response = await httpClient.SendAsync(request);
            if (onResponse != null)
            {
                onResponse(response);
            }
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var ujumberResponse = JsonSerializer.Deserialize<UjumbeResponse>(responseString);
                if (ujumberResponse != null)
                {
                    return ujumberResponse;
                }
                else
                {
                    throw new Exception("Unable to get response from message sending");
                }
            }
            else
            {
                throw new Exception($"Unable to send message. Status code: {response.StatusCode}");
            }
        }
    }

}