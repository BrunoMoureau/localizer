using System;
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
    public partial class SettingsPage : ILocalizable
    {
        public ICommand OptionTappedCommand { get; }

        public SettingsPage()
        {
            InitializeComponent();
            OptionTappedCommand = new Command<Option<string>>(OnCultureOptionSelected);

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

        protected override void OnParentSet()
        {
            base.OnParentSet();

            if (Parent == null) // Page is removed from navigation stack
            {
                DependencyService.Get<ILocalizer>().Unsubscribe(this);
            }
            else // Page is added to navigation stack
            {
                DependencyService.Get<ILocalizer>().Subscribe(this);
            }
        }

        public void OnCultureChanged(object sender, CultureInfo cultureInfo)
        {
            Trace.WriteLine($"Update culture of {nameof(SettingsPage)}");

            Title = AppResources.SettingsPage_TitleText;
            LanguageSectionLabel.Text = AppResources.SettingsPage_LanguageSectionText;
            FormatSectionLabel.Text = AppResources.SettingsPage_FormatSectionText;
            LanguageFormatLabel.Text = AppResources.SettingsPage_LanguageFormatText;
            DateTimeFormatLabel.Text = $"{DateTime.Now:f}";

            var numberExample = (double)Resources.Values.ElementAt(0);
            var percentExample = (double)Resources.Values.ElementAt(1);
            var priceExample = (double)Resources.Values.ElementAt(2);

            NumberFormatLabel.Text = $"{numberExample:N}";
            PercentFormatLabel.Text = $"{percentExample:P}";
            PriceFormatLabel.Text = $"{priceExample:C}";

            FillCultureOptions();
        }

        private void OnCultureOptionSelected(Option<string> selectedCultureOption)
        {
            if (selectedCultureOption.IsSelected)
            {
                Trace.WriteLine("The culture option is already selected");
                return;
            }

            var cultureInfo = new CultureInfo(selectedCultureOption.Value);
            if (CultureListView.ItemsSource is IEnumerable<Option<string>> cultureOptions)
            {
                Trace.WriteLine("Unselect all culture options");
                foreach (Option<string> cultureOption in cultureOptions)
                {
                    cultureOption.IsSelected = false;
                }
            }

            Trace.WriteLine("The tapped option is now selected");
            selectedCultureOption.IsSelected = true;

            DependencyService.Get<ILocalizer>().SetCulture(cultureInfo);
        }
    }
}