using System.Globalization;

namespace LocalizedApp.Components.Localizer.Interfaces
{
    public interface ILocalizable
    {
        void OnCultureChanged(object sender, CultureInfo cultureInfo);
    }
}
