using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UjumbeSmsSdk.Response
{
    /// <summary>
    /// Represents the response date and time information in the Ujumbe system.
    /// </summary>
    public class UjumbeResponseDateTime
    {
        /// <summary>
        /// Gets or sets the date in the response.
        /// </summary>
        [JsonPropertyName("date")]
        public string Date { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the timezone type in the response.
        /// </summary>
        [JsonPropertyName("timezone_type")]
        public int TimezoneType { get; set; }

        /// <summary>
        /// Gets or sets the timezone in the response.
        /// </summary>
        [JsonPropertyName("timezone")]
        public string Timezone { get; set; } = string.Empty;
    }

}