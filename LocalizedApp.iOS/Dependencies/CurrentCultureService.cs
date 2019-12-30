using System.Linq;
using Foundation;
using LocalizedApp.Components.Localizer.Interfaces.Dependencies;
using Xamarin.Forms;
using LocalizedApp.iOS.Dependencies;

[assembly: Dependency(typeof(CurrentCultureService))]
namespace LocalizedApp.iOS.Dependencies
{
    public class CurrentCultureService : ICurrentCulture
    {
        public string GetPreferredUserCulture()
        {
            return NSLocale.PreferredLanguages.ElementAtOrDefault(0);
        }
    }
}