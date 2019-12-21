﻿using System;
using System.Diagnostics;
using System.Globalization;
using LocalizedApp.Components.Localizer.Interfaces;
using LocalizedApp.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocalizedApp.Pages.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ILocalizable
    {
        public HomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();

            if (Parent == null) // Page is removed from navigation stack
            {
                App.Localizer.Unsubscribe(this);
            }
            else // Page is added to navigation stack
            {
                App.Localizer.Subscribe(this);
            }
        }

        private void OnNavigationButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Settings.SettingsPage());
        }

        public void OnCultureChanged(object sender, CultureInfo cultureInfo)
        {
            Trace.WriteLine($"Update culture of {nameof(HomePage)}"); // Not running on UWP without this line ??

            GreetingsLabel.Text = AppResources.HomePage_GreetingsText;
            CurrentCultureLabel.Text = AppResources.HomePage_CurrentCultureText;
            SelectCultureButton.Text = AppResources.HomePage_SelectCultureText;
        }
    }
}