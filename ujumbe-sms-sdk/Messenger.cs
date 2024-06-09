using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
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
                responseString = GetCleanedJsonString(responseString);
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

        /// <summary>
        /// This method takes a string input and attempts to find a JSON object within it.
        /// If a JSON object is found, it is returned. If no JSON object is found, the original input is returned.
        /// </summary>
        /// <param name="input">The string that may or may not contain JSON. Must not be null.</param>
        /// <returns>The JSON object that was found within the input string, or the original input string if no JSON object was found.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the input string is null.</exception>
        private string GetCleanedJsonString(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input), "Input string cannot be null");
            }

            // Define a regular expression pattern that matches a JSON object
            // The pattern looks for a curly brace that is not part of a larger JSON object
            // This is done using a balancing group called "open" that tracks the number of open curly braces
            // The pattern is designed to match the entire JSON object, including surrounding curly braces
            string pattern = @"\{(?:[^{}]|(?<open>\{)|(?<-open>\}))*(?(open)(?!))\}";

            // Use Regex to find the JSON object within the input string
            var match = Regex.Match(input, pattern, RegexOptions.Singleline);

            // If a JSON object was found...
            if (match.Success)
            {
                // Extract the JSON object from the input string
                string jsonString = match.Value;
                // Return the JSON object
                return jsonString;
            }
            // If no JSON object was found...
            else
            {
                // Return the original input string
                return input;
            }
        }
    }

}