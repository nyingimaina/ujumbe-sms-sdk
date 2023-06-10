using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UjumbeSmsSdk.Request
{
    /// <summary>
    /// Represents a message bag containing phone numbers, message content, and sender information.
    /// </summary>
    public class MessageBag
    {
        /// <summary>
        /// Gets or sets a HashSet of phone numbers.
        /// </summary>
        [JsonIgnore]
        public HashSet<string> PhoneNumbers { get; set; } = new HashSet<string>();

        /// <summary>
        /// Gets or sets a comma-separated string representation of the phone numbers.
        /// This is read-only and gotten from the HashSet of phone numbers.
        /// </summary>
        [JsonPropertyName("numbers")]
        public string Numbers => string.Join(",", PhoneNumbers);

        /// <summary>
        /// Gets or sets the message content.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the sender ID.
        /// </summary>
        [JsonPropertyName("sender")]
        public string SenderId { get; set; } = string.Empty;
    }

}