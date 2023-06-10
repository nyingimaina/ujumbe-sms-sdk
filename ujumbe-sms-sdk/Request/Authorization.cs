using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UjumbeSmsSdk.Request
{
    /// <summary>
    /// Represents the authorization details for accessing the Ujumbe SMS API.
    /// </summary>
    public class Authorization
    {
        /// <summary>
        /// Gets or sets the API key for authentication.
        /// </summary>
        public string ApiKey { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets your email associated with the API key. This is usually the email for the account which you used to obtain the API key.
        /// </summary>
        public string YourEmail { get; set; } = string.Empty;
    }

}