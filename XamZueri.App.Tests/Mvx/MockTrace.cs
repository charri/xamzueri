using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Platform.Platform;

namespace XamZueri.App.Tests.Mvx
{
    public class MockTrace : IMvxTrace
    {
        public void Trace(MvxTraceLevel level, string tag, Func<string> message)
        {
            Debug.WriteLine(tag + ":" + level + ":" + message());
        }

        public void Trace(MvxTraceLevel level, string tag, string message)
        {
            Debug.WriteLine(tag + ": " + level + ": " + message);
        }

        public void Trace(MvxTraceLevel level, string tag, string message, params object[] args)
        {
            if (args == null || args.Length == 0)
            {
                Trace(level, tag, message);
                return;
            }

            Debug.WriteLine(tag + ": " + level + ": " + message, args);
        }
    }
}
