using System;
using System.Globalization;
using System.Linq;

namespace LocalizedApp.Components.Localizer.Models
{
    public class CultureBuilder 
    {
        public CultureInfo CultureInfo { get; }

        public CultureBuilder(string cultureName)
        {
            if (string.IsNullOrWhiteSpace(cultureName))
            {
                throw new ArgumentException();
            }

            CultureInfo = GetCultureInfo(cultureName);
        }

        private CultureInfo GetCultureInfo(string cultureName)
        {
            // Get equivalent .NET culture
            string dotNetFullCultureName = cultureName?.Replace('_', '-');
            string fullCultureName = ConvertToDotNetFullCultureFormat(dotNetFullCultureName);

            try
            {
                // Get CultureInfo using .NET culture format
                return new CultureInfo(fullCultureName);
            }
            catch (CultureNotFoundException)
            {
                // Invalid .NET culture (eg. iOS "en-ES" : English in Spain)
                // Only get and use the first part of the culture (eg. "en")

                string[] split = fullCultureName.Split('-');
                string twoLetterCulture = split.ElementAtOrDefault(0); // Get the two letters culture name
                string dotNetTwoLetterCulture = ConvertToDotNetTwoLetterCultureFormat(twoLetterCulture);

                try
                {                    
                    return new CultureInfo(dotNetTwoLetterCulture);
                }
                catch (CultureNotFoundException)
                {
                    // Fallback using the generic "en" culture
                    return new CultureInfo("en");
                }
            }
        }

        private string ConvertToDotNetFullCultureFormat(string cultureName)
        {
            switch (cultureName)
            {
                // add more application-specific cases here (if required)
                // ONLY use cultures that have been tested and known to work
                /* Examples :
                case "ms-BN": // "Malaysian (Brunei)" not supported .NET culture
                case "ms-MY": // "Malaysian (Malaysia)" not supported .NET culture
                case "ms-SG": // "Malaysian (Singapore)" not supported .NET culture
                    return "ms";
                */
                default: return cultureName;
            }
        }

        private string ConvertToDotNetTwoLetterCultureFormat(string twoLetterCultureName)
        {
            switch (twoLetterCultureName)
            {
                // add more application-specific cases here (if required)
                // ONLY use cultures that have been tested and known to work
                /* Examples :
                case "gsw": return "de-CH"; // German (Switzerland)
                */
                default: return twoLetterCultureName;
            }
        }
    }
}