namespace LocalizedApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new LocalizedApp.App());
        }
    }
}
