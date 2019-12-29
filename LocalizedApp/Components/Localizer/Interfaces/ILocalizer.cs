using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LocalizedApp.Components.Localizer.Interfaces
{
    public interface ILocalizer
    {

        /// <summary>
        /// Subscribe the ILocalizable instance to the culture changes.
        /// This behavior is perfomed using MessagingCenter.
        /// </summary>
        /// <param name="localizable">ILocalizable instance to subscribe</param>
        void Subscribe(ILocalizable localizable);

        /// <summary>
        /// Unsubscribe the ILocalizable instance to the culture changes.
        /// This behavior is perfomed using MessagingCenter.
        /// </summary>
        /// <param name="localizable">ILocalizable instance to unsubscribe</param>
        void Unsubscribe(ILocalizable localizable);

        /// <summary>
        /// Set the app culture (AppResources, MainThread...)
        /// If the given culture is invalid, the user preffered culture is used instead.
        /// If the user preffered culture is unknown, 
        /// </summary>
        /// <param name="cultureName">Culture name (eg. "en-US")</param>
        void SetCulture(string cultureName);

        void SetCulture(CultureInfo cultureInfo);
    }
}
