using System.Threading.Tasks;
using LocalizedApp.Resources;
using Xamarin.Forms;

namespace LocalizedApp.Helpers
{
    public static class Alert
    {
        public static Task RestartAppToApplyCultureChangesAsync() => Show(AppResources.Alert_RestartAppToApplyCultureChangesTitle, AppResources.Alert_RestartAppToApplyCultureChangesMessage);

        private static Task Show(string title, string message)
        {
            return Application.Current.MainPage.DisplayAlert(title, message, AppResources.Alert_Cancel);
        }
    }
}
