using System.Linq;
using LocalizedApp.Components.Localizer.Interfaces.Dependencies;
using LocalizedApp.UWP.Dependencies;
using Xamarin.Forms;

[assembly: Dependency(typeof(ResourceLocalizerService))]
namespace LocalizedApp.UWP.Dependencies
{
    public class ResourceLocalizerService : ILocalizerService
    {
        public string GetPreferredUserCulture()
        {
            return Windows.Globalization.ApplicationLanguages.Languages.ElementAtOrDefault(0);
        }
    }
}