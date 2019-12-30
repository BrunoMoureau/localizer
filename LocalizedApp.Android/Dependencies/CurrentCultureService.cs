using LocalizedApp.Components.Localizer.Interfaces.Dependencies;
using Xamarin.Forms;
using LocalizedApp.Droid.Dependencies;

[assembly:Dependency(typeof(CurrentCultureService))]
namespace LocalizedApp.Droid.Dependencies
{
    public class CurrentCultureService : ICurrentCulture
    {
        public string GetPreferredUserCulture()
        {
            return Java.Util.Locale.Default?.ToString();
        }
    }
}