using Xamarin.UITest;

namespace UnitTest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .ApkFile("C:/Repo/SampleApps/LocalizedApp/LocalizedApp.Android/bin/Release/com.companyname.localizedapp.apk")
                    .StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}