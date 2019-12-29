using LocalizedApp.Components.Localizer.Interfaces;
using LocalizedApp.Pages.Home;
using Xamarin.Forms;

namespace LocalizedApp
{
    /*
     * Tuto :
     * - Ajouter les ressources dans des resx
     * - Le premier resx possède une proprité Custom Tool PublicResXFileCodeGenerator pour générer une classe et doit être publique
     * - Les autres resx doivent comporter une nom reprenant la culture (ex: AppResources.en.resx ou AppResources.fr.resx)
     * - Il faut ajouter la culture par défaut à utiliser dans l'AssemblyInfo.cs (ex: [assembly: NeutralResourcesLanguage("en")])
     */
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            // Could provide culture form AppSettings here
            DependencyService.Get<ILocalizer>().SetCulture("en-US");
            
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
