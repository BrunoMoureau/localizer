using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using LocalizedApp.Components.Localizer.Interfaces;
using LocalizedApp.Models;
using LocalizedApp.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocalizedApp.Pages.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage
    {
        private ICommand _optionTappedCommand;
        public ICommand OptionTappedCommand => _optionTappedCommand ?? (_optionTappedCommand = new Command<Option<string>>(option => 
        {
            if (option.IsSelected)
            {
                Trace.WriteLine("The culture option is already selected");
                return;
            }

            var cultureInfo = new CultureInfo(option.Value);
            if (CultureListView.ItemsSource is IEnumerable<Option<string>> cultureOptions)
            {
                Trace.WriteLine("Unselecting all culture options");
                foreach (Option<string> cultureOption in cultureOptions)
                {
                    cultureOption.IsSelected = false;
                }
            }

            option.IsSelected = true;
            Trace.WriteLine("The tapped option is now selected");

            DependencyService.Get<ILocalizer>().SetCulture(cultureInfo);
        }));

        public SettingsPage()
        {
            InitializeComponent();
            FillCultureOptions();
        }

        private void FillCultureOptions()
        {
            var cultureOptions = GetCultureOptions();

            SelectCurrentCultureOption(cultureOptions);

            Trace.WriteLine("Assign culture options to the ListView");
            CultureListView.ItemsSource = cultureOptions;
        }

        private static Option<string>[] GetCultureOptions()
        {
            Trace.WriteLine("Get new culture options");

            return new[]
            {
                new Option<string>(false, "fr", AppResources.SettingsPage_fr_LanguageText),
                new Option<string>(false, "en-US", AppResources.SettingsPage_en_US_LanguageText, AppResources.SettingsPage_en_US_LanguageDescriptionText),
                new Option<string>(false, "en-GB", AppResources.SettingsPage_en_GB_LanguageText, AppResources.SettingsPage_en_GB_LanguageDescriptionText),
            };
        }

        private void SelectCurrentCultureOption(Option<string>[] cultureOptions)
        {
            Trace.WriteLine("Select the current AppResources culture option");

            var cultureOption = 
                cultureOptions.FirstOrDefault(o => string.Equals(o.Value, AppResources.Culture.Name)) // perfect match (e.g. en-US)
                ?? cultureOptions.FirstOrDefault(o => string.Equals(o.Value, AppResources.Culture.Parent.Name)) // parent match (e.g. en)
                ?? cultureOptions.First(o => o.Value.Contains(AppResources.Culture.Name)); // current culture is a parent (e.g. en)

            cultureOption.IsSelected = true;
        }
    }
}