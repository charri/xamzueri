using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.Presenter.Core;
using MvvmCross.Forms.Presenter.iOS;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using UIKit;
using Xamarin.Forms;
using XamZueri.App.iOS.PlatformServices;
using XamZueri.App.Services;

namespace XamZueri.App.iOS
{
    public class Setup : MvxIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new AppStart();
        }

        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();

            Mvx.RegisterType<ISocialShareService, AppleSocialShareService>();
        }

		protected override void InitializeLastChance ()
		{
			base.InitializeLastChance ();
		}

		protected override void InitializeCommandHelper ()
		{
			// using weak command helper does not work
			Mvx.RegisterType<IMvxCommandHelper, MvxStrongCommandHelper> ();
		}

        protected override IMvxIosViewPresenter CreatePresenter()
        {
            Forms.Init();

			Forms.ViewInitialized += (object sender, ViewInitializedEventArgs e) => {
				// http://developer.xamarin.com/recipes/testcloud/set-accessibilityidentifier-ios/
				if (null != e.View.StyleId) {
					e.NativeView.AccessibilityIdentifier = e.View.StyleId;
				}
			};

            var xamarinFormsApp = new MvxFormsApp();

            return new MvxFormsIosPagePresenter(Window, xamarinFormsApp);
        }
    }
}