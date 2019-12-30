using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace LocalizedApp.Helpers
{
    internal static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public const string DefaultCultureName = "en-US";

        public static string CultureName
        {
            get => AppSettings.GetValueOrDefault(nameof(CultureName), null);
            set => AppSettings.AddOrUpdateValue(nameof(CultureName), value);
        }
    }
}
