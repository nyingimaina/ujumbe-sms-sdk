using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UjumbeSmsSdk.Response
{
    /// <summary>
    /// Represents the overall response from Ujumbe.
    /// </summary>
    public class UjumbeResponse
    {
        /// <summary>
        /// Gets or sets the status information in the response.
        /// </summary>
        [JsonPropertyName("status")]
        public UjumbeResponseStatus Status { get; set; } = new UjumbeResponseStatus();

        /// <summary>
        /// Gets or sets the meta information in the response.
        /// </summary>
        [JsonPropertyName("meta")]
        public UjumbeResponseMeta Meta { get; set; } = new UjumbeResponseMeta();

        /// <summary>
        /// Gets or sets a value that indicates whether the request was successful or not.
        /// </summary>
        public bool Success
        {
            get
            {
                return Status != null && Status.Code == "1008" && Status.Type.Trim().ToUpperInvariant() == "SUCCESS";
            }
        }
    }

}