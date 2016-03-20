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
using Xamarin;
using XamZueri.App.Droid.PlatformServices;

namespace XamZueri.App.Droid
{

    [Application(
#if DEBUG
        Debuggable = true,
#else
        Debuggable = false,
#endif
        Theme = "@style/MyTheme", Label = "@string/app_title")]

    public class XamZueriApplication
        : Application
    {
        protected XamZueriApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
                AppStart.OnUnhandledException(args.ExceptionObject as Exception, args.IsTerminating);

            Insights.Initialize(Settings.Default.XamarinInsights, this);

            RegisterActivityLifecycleCallbacks(MvxFormsActivityLifecycleCallbacks.Instance);
        }

        public override void OnTerminate()
        {
            base.OnTerminate();

            UnregisterActivityLifecycleCallbacks(MvxFormsActivityLifecycleCallbacks.Instance);
        }
    }
}