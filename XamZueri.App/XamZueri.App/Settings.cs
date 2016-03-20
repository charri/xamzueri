using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamZueri.App
{
    public class Settings
    {
        private static readonly Lazy<Settings> Instance = new Lazy<Settings>(() => new Settings());

        public static Settings Default => Instance.Value;

        public string XamarinInsights { get; private set; }

        public string Host { get; private set; }

        public string MeetupApi { get; private set; }

        private Settings()
        {
            // Production Values
            XamarinInsights = "f2d31dd80279dd639d3ceec211a4e3a3f8514dd7";
            Host = "http://xamzueri.ch/";
            MeetupApi = "https://api.meetup.com/xamarin-zurich/events/{0}";

#if DEBUG
            XamarinInsights = Xamarin.Insights.DebugModeKey;
#endif
        }
        
    }
}
