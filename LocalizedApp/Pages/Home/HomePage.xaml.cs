using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocalizedApp.Pages.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage
    {
        public HomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void OnNavigationButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Settings.SettingsPage());
        }
    }
}