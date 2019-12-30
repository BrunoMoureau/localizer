using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using LocalizedApp.Components.Localizer;
using LocalizedApp.Components.Localizer.Interfaces;
using LocalizedApp.Components.Localizer.Interfaces.Dependencies;
using LocalizedApp.Components.Localizer.Models;
using LocalizedApp.Helpers;
using LocalizedApp.Resources;
using Xamarin.Forms;

[assembly: Dependency(typeof(Localizer))]
namespace LocalizedApp.Components.Localizer
{
    public class Localizer : ILocalizer
    {
        public string FallbackCultureName { get; set; }

        public Localizer()
        {

        }

        /// <summary>
        /// Set the app culture (AppResources, MainThread...)
        /// If the given culture is invalid, the user preffered culture is used instead.
        /// If the user preffered culture is unknown, 
        /// </summary>
        /// <param name="cultureName">Culture name (eg. "en-US")</param>
        public void SetCulture(string cultureName)
        {
            try
            {
                Trace.WriteLine($"Tring to set culture of \"{cultureName}\"");
                var cultureInfo = new CultureInfo(cultureName);
                Trace.WriteLine($"\"{cultureName}\" format is valid");
                SetCulture(cultureInfo);
            }
            catch (Exception)
            {
                Trace.WriteLine($"\"{cultureName}\" format is invalid");
                SetDefaultCulture();
            }
        }

        public void SetCulture(CultureInfo cultureInfo)
        {
            Trace.WriteLine("Update AppResources culture");
            AppResources.Culture = cultureInfo; // Set the RESX for resource localization

            Trace.WriteLine("Update current thread culture");
            Thread.CurrentThread.CurrentCulture = cultureInfo; // Set the Thread for locale-aware methods
            Thread.CurrentThread.CurrentUICulture = cultureInfo; // Set the Thread for locale-aware methods

            Settings.CultureName = cultureInfo.Name;
        }
        
        private void SetDefaultCulture()
        {
            var preferredCulture = DependencyService.Get<ICurrentCulture>().GetPreferredUserCulture();
            var culture = string.IsNullOrEmpty(preferredCulture) ? FallbackCultureName : preferredCulture;

            var cultureBuilder = new CultureBuilder(culture);
            SetCulture(cultureBuilder.CultureInfo);
        }
    }
}