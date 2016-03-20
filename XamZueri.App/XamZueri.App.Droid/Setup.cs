using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Views;
using MvvmCross.Forms.Presenter.Droid;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using XamZueri.App.Droid.PlattformServices;
using XamZueri.App.Services;

namespace XamZueri.App.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext)
            : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new AppStart();
        }

        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();

            Mvx.RegisterType<ISocialShareService, AndroidSocialShareService>();

        }


        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var presenter = new MvxFormsDroidPagePresenter();

            Mvx.RegisterSingleton<IMvxViewPresenter>(presenter);

            return presenter;
        }
    }
}