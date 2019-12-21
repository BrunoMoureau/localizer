using System;
using System.Globalization;
using System.Linq;

namespace LocalizedApp.Components.Localizer.Models
{
    public class CultureBuilder 
    {
        public CultureInfo CultureInfo { get; }

        public CultureBuilder(string culture)
        {
            if (string.IsNullOrWhiteSpace(culture))
            {
                throw new ArgumentException();
            }

            CultureInfo = GetCultureInfo(culture);
        }

        private CultureInfo GetCultureInfo(string culture)
        {
            // Get equivalent .NET culture
            string dotNetCultureFormat = ConvertToDotNetFullCultureFormat(culture);

            try
            {
                // Get CultureInfo using .NET culture format
                return new CultureInfo(dotNetCultureFormat);
            }
            catch (CultureNotFoundException)
            {
                // Invalid .NET culture (eg. iOS "en-ES" : English in Spain)
                // Only get and use the first part of the culture (eg. "en")
                try
                {
                    string[] split = culture.Split('_', '-'); // Some culture formats use underscore as separator
                    string twoLetterCulture = split.ElementAtOrDefault(0); // Get the first part of the culture
                    string dotNetTwoLetterCulture = ConvertToDotNetTwoLetterCultureFormat(twoLetterCulture);

                    return new CultureInfo(dotNetTwoLetterCulture);
                }
                catch (CultureNotFoundException)
                {
                    // Fallback using the generic "en" culture
                    return new CultureInfo("en");
                }
            }
        }

        private string ConvertToDotNetFullCultureFormat(string culture)
        {
            switch (culture)
            {
                // add more application-specific cases here (if required)
                // ONLY use cultures that have been tested and known to work
                /* Examples :
                case "ms-BN": // "Malaysian (Brunei)" not supported .NET culture
                case "ms-MY": // "Malaysian (Malaysia)" not supported .NET culture
                case "ms-SG": // "Malaysian (Singapore)" not supported .NET culture
                    return "ms";
                */
                default: return culture;
            }
        }

        private string ConvertToDotNetTwoLetterCultureFormat(string twoLetterCulture)
        {
            switch (twoLetterCulture)
            {
                // add more application-specific cases here (if required)
                // ONLY use cultures that have been tested and known to work
                /* Examples :
                case "gsw": return "de-CH"; // German (Switzerland)
                */
                default: return "en";
            }
        }
    }
}