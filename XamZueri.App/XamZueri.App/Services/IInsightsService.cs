using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin;

namespace XamZueri.App.Services
{
    interface IInsightsService
    {
        void Identify(string uid, IDictionary<string, string> table = null);
        void Identify(string uid, string key, string value);
        Task PurgePendingCrashReports();
        void Report(Exception exception = null, Insights.Severity warningLevel = Insights.Severity.Warning);
        void Report(Exception exception, IDictionary extraData, Insights.Severity warningLevel = Insights.Severity.Warning);
        void Report(Exception exception, string key, string value, Insights.Severity warningLevel = Insights.Severity.Warning);
        Task Save();
        void Track(string trackIdentifier, IDictionary<string, string> table = null);
        void Track(string trackIdentifier, string key, string value);
        ITrackHandle TrackTime(string identifier, IDictionary<string, string> table = null);
        ITrackHandle TrackTime(string identifier, string key, string value);
    }
}
