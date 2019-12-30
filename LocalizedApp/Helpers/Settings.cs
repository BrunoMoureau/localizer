using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace LocalizedApp.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static string CultureName
        {
            get => AppSettings.GetValueOrDefault(nameof(CultureName), null);
            set => AppSettings.AddOrUpdateValue(nameof(CultureName), value);
        }
    }
}
