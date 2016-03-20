using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Platform;
using XamZueri.App.Services;

namespace XamZueri.App.Infrastructure
{
    public class MvxLoggerService : ILogger
    {
        private readonly string _tag;

        public MvxLoggerService(string tag)
        {
            _tag = tag;
        }

        public void Debug(string message)
        {
            Debug("{0}", message);
        }

        public void Debug(string format, params object[] args)
        {
            Mvx.TaggedTrace(_tag, format, args);
        }

        public void Info(string message)
        {
            Debug("{0}", message);
        }

        public void Info(string format, params object[] args)
        {
            Debug(format, args);
        }

        public void Warn(string message)
        {
            Warn("{0}", message);
        }

        public void Warn(string format, params object[] args)
        {
            Mvx.TaggedWarning(_tag, format, args);
        }

        public void Error(string message)
        {
            Error("{0}", message);
        }

        public void Error(string format, params object[] args)
        {
            Mvx.TaggedError(_tag, format, args);
        }

        public void Error(Exception ex)
        {
            Error("{0}", ex);
        }
    }

}
