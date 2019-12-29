using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using LocalizedApp.Components.Localizer;
using LocalizedApp.Components.Localizer.Interfaces;
using LocalizedApp.Components.Localizer.Interfaces.Dependencies;
using LocalizedApp.Components.Localizer.Models;
using LocalizedApp.Resources;
using Xamarin.Forms;

[assembly: Dependency(typeof(Localizer))]
namespace LocalizedApp.Components.Localizer
{
    public class Localizer : ILocalizer
    {
        private const string CULTURE_CHANGED_MESSAGE = "CultureChanged";
        public string FallbackCulture { get; } = "en";

        public Localizer()
        {

        }

        /// <summary>
        /// Subscribe the ILocalizable instance to the culture changes.
        /// This behavior is perfomed using MessagingCenter.
        /// </summary>
        /// <param name="localizable">ILocalizable instance to subscribe</param>
        public void Subscribe(ILocalizable localizable)
        {
            MessagingCenter.Subscribe<Localizer, CultureInfo>(localizable, CULTURE_CHANGED_MESSAGE, localizable.OnCultureChanged);
        }

        /// <summary>
        /// Unsubscribe the ILocalizable instance to the culture changes.
        /// This behavior is perfomed using MessagingCenter.
        /// </summary>
        /// <param name="localizable">ILocalizable instance to unsubscribe</param>
        public void Unsubscribe(ILocalizable localizable)
        {
            MessagingCenter.Unsubscribe<Localizer, CultureInfo>(localizable, CULTURE_CHANGED_MESSAGE);
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

            Trace.WriteLine("Notify culture changes to subscribed instances");
            MessagingCenter.Send(this, CULTURE_CHANGED_MESSAGE, cultureInfo);
        }
        
        private void SetDefaultCulture()
        {
            var preferredCulture = DependencyService.Get<ICurrentCulture>().GetPreferredUserCulture();
            var culture = string.IsNullOrEmpty(preferredCulture) ? FallbackCulture : preferredCulture;

            var cultureBuilder = new CultureBuilder(culture);
            SetCulture(cultureBuilder.CultureInfo);
        }
    }
}