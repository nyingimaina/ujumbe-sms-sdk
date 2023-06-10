using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UjumbeSmsSdk.Response
{
    /// <summary>
    /// Represents the meta information in the Ujumbe response.
    /// </summary>
    public class UjumbeResponseMeta
    {
        /// <summary>
        /// Gets or sets the recipients in the response.
        /// </summary>
        [JsonPropertyName("recipients")]
        public long Recipients { get; set; }

        /// <summary>
        /// Gets or sets the credits deducted in the response.
        /// </summary>
        [JsonPropertyName("credits_deducted")]
        public decimal CreditsDeducted { get; set; }

        /// <summary>
        /// Gets or sets the available credits in the response.
        /// </summary>
        [JsonPropertyName("available_credits")]
        public object AvailableCredits { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email of the user in the response.
        /// </summary>
        [JsonPropertyName("user_email")]
        public string UserEmail { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date and time information in the response.
        /// </summary>
        [JsonPropertyName("date_time")]
        public UjumbeResponseDateTime DateTime { get; set; } = new UjumbeResponseDateTime();
    }

}