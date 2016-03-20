using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace XamZueri.App.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException +=
                (sender, arg) => { AppStart.OnUnhandledException(arg.ExceptionObject as Exception, arg.IsTerminating); };

            Xamarin.Insights.Initialize(Settings.Default.XamarinInsights);
            
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
