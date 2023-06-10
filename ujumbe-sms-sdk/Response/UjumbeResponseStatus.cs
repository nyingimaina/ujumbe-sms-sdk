using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UjumbeSmsSdk.Response
{
    /// <summary>
    /// Represents the status information in the Ujumbe response.
    /// </summary>
    public class UjumbeResponseStatus
    {
        /// <summary>
        /// Gets or sets the code in the response.
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the type in the response.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description in the response.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
    }

}