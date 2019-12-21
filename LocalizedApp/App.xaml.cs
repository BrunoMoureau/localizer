using LocalizedApp.Components.Localizer;
using LocalizedApp.Pages.Home;
using Xamarin.Forms;

namespace LocalizedApp
{
    //todo
    // read https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/localization/text?pivots=windows
    // and support RTL (Right To Left) if possible
    // + add languages to iOS pList and UWP



    /*
     * Tuto :
     * - Ajouter les ressources dans des resx
     * - Le premier resx possède une proprité Custom Tool PublicResXFileCodeGenerator pour générer une classe et doit être publique
     * - Les autres resx doivent comporter une nom reprenant la culture (ex: AppResources.en.resx ou AppResources.fr.resx)
     * - Il faut ajouter la culture par défaut à utiliser dans l'AssemblyInfo.cs (ex: [assembly: NeutralResourcesLanguage("en")])
     */
    public partial class App : Application
    {
        public static Localizer Localizer => (Localizer)Current.Resources["Localizer"];

        public App()
        {
            InitializeComponent();

            // Could provide culture form AppSettings here and
            // update the AppSettings key using CultureChanged event
            Localizer.SetCulture("en");

            MainPage = new NavigationPage(new HomePage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
