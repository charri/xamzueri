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

        protected override IMvxIosViewPresenter CreatePresenter()
        {
            Forms.Init();

            var xamarinFormsApp = new MvxFormsApp();

            return new MvxFormsIosPagePresenter(Window, xamarinFormsApp);
        }
    }
}