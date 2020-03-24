using System.Globalization;

namespace LocalizedApp.Components.Localizer.Interfaces
{
    public interface ILocalizer
    {
        /// <summary>
        /// Set the app culture (AppResources, MainThread...)
        /// If the given culture is invalid, the user preferred culture is used instead.
        /// </summary>
        /// <param name="cultureName">Culture name (eg. "en-US")</param>
        void SetCulture(string cultureName);

        void SetCulture(CultureInfo cultureInfo);
        void SetDefaultCulture();
    }
}
