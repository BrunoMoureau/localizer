using System.Linq;

using Foundation;
using LocalizedApp.Components.Localizer.Interfaces.Dependencies;
using Xamarin.Forms;
using LocalizedApp.iOS.Dependencies;

[assembly: Dependency(typeof(ResourceLocalizerService))]
namespace LocalizedApp.iOS.Dependencies
{
    public class ResourceLocalizerService : ILocalizerService
    {
        public string GetPreferredUserCulture()
        {
            return NSLocale.PreferredLanguages.ElementAtOrDefault(0);
        }
    }
}