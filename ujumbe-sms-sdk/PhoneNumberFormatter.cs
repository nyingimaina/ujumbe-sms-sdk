using System.Text.RegularExpressions;

namespace UjumbeSmsSdk
{


    /// <summary>
    /// Utility class for formatting phone numbers with optional country codes.
    /// </summary>
    public class PhoneNumberFormatter
    {
        /// <summary>
        /// Formats the provided phone number with an optional country code.
        /// </summary>
        /// <param name="phoneNumber">The phone number to format.</param>
        /// <param name="countryCode">The country code to prepend (optional).</param>
        /// <returns>The formatted phone number.</returns>
        public string FormatPhoneNumber(string phoneNumber, int? countryCode = null)
        {
            // Remove any non-digit characters from the phone number
            string digitsOnly = Regex.Replace(phoneNumber, @"[^\d]", "");

            // Check if a country code is provided and add it to the formatted number
            if (countryCode != null && countryCode.Value > 0)
            {
                digitsOnly = "+" + countryCode.Value.ToString() + digitsOnly;
            }

            return digitsOnly;
        }
    }

}