using System.Globalization;

namespace LocalizedApp.Components.Localizer.Interfaces
{
    public interface ILocalizer
    {
        /// <summary>
        /// Set the app culture (AppResources, MainThread...)
        /// If the given culture is invalid, the user preffered culture is used instead.
        /// If the user preffered culture is unknown, 
        /// </summary>
        /// <param name="cultureName">Culture name (eg. "en-US")</param>
        void SetCulture(string cultureName);

        void SetCulture(CultureInfo cultureInfo);
    }
}
