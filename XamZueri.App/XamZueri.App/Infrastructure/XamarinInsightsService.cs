using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin;
using XamZueri.App.Services;

namespace XamZueri.App.Infrastructure
{
    public class XamarinInsightsService
        : IInsightsService
    {
        public void Identify(string uid, IDictionary<string, string> table = null)
        {
            Insights.Identify(uid, table);
        }

        public void Identify(string uid, string key, string value)
        {
            Insights.Identify(uid, key, value);
        }

        public Task PurgePendingCrashReports()
        {
            return Insights.PurgePendingCrashReports();
        }

        public void Report(Exception exception = null, Insights.Severity warningLevel = Insights.Severity.Warning)
        {
            Insights.Report(exception, warningLevel);
        }

        public void Report(Exception exception, IDictionary extraData, Insights.Severity warningLevel = Insights.Severity.Warning)
        {
            Insights.Report(exception, extraData, warningLevel);
        }

        public void Report(Exception exception, string key, string value, Insights.Severity warningLevel = Insights.Severity.Warning)
        {
            Insights.Report(exception, key, value, warningLevel);
        }

        public Task Save()
        {
            return Insights.Save();
        }

        public void Track(string trackIdentifier, IDictionary<string, string> table = null)
        {
            Insights.Track(trackIdentifier, table);
        }

        public void Track(string trackIdentifier, string key, string value)
        {
            Insights.Track(trackIdentifier, key, value);
        }

        public ITrackHandle TrackTime(string identifier, IDictionary<string, string> table = null)
        {
            return Insights.TrackTime(identifier, table);
        }

        public ITrackHandle TrackTime(string identifier, string key, string value)
        {
            return Insights.TrackTime(identifier, key, value);
        }
    }
}
