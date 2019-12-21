using LocalizedApp.Components.Localizer.Interfaces.Dependencies;
using Xamarin.Forms;

using LocalizedApp.Droid.Dependencies;

[assembly:Dependency(typeof(LocalizerService))]
namespace LocalizedApp.Droid.Dependencies
{
    public class LocalizerService : ILocalizerService
    {
        public string GetPreferredUserCulture()
        {
            return Java.Util.Locale.Default?.ToString();
        }
    }
}