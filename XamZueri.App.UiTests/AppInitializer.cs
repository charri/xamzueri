using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XamZueri.App.UiTests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            switch (platform)
            {
                case Platform.Android:
                    return ConfigureApp
                        .Android
                        .PreferIdeSettings()
                        .ApkFile(@"..\..\..\XamZueri.App\XamZueri.App.Droid\bin\Release\ch.xamzueri.app.apk")
                        .EnableLocalScreenshots()
                        .StartApp();
                case Platform.iOS:
                    return ConfigureApp
                        .iOS
                        .StartApp();
            }

            throw new Exception("AppInitializer: Unsupported platform " + platform);
        }


    }
}

