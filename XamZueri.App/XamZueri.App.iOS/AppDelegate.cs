using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;
using UIKit;

namespace XamZueri.App.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxApplicationDelegate
    {
        UIWindow _window;
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
			#if ENABLE_TEST_CLOUD
			// requires Xamarin Test Cloud Agent
			Xamarin.Calabash.Start();
			#endif


            _window = new UIWindow(UIScreen.MainScreen.Bounds);

            var setup = new Setup(this, _window);
            setup.Initialize();

            var startup = Mvx.Resolve<IMvxAppStart>();
            startup.Start();

            _window.MakeKeyAndVisible();


            return true;
        }
    }
}
