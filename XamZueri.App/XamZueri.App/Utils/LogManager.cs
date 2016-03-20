using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Platform;
using XamZueri.App.Annotations;
using XamZueri.App.Infrastructure;
using XamZueri.App.Services;

namespace XamZueri.App.Utils
{
    public static class LogManager
    {
        [NotNull]
        public static ILogger GetLogger(string name)
        {
            return new MvxLoggerService(name);
        }

        [NotNull]
        public static ILogger GetLogger(Type loggerType)
        {
            return GetLogger(loggerType.Name);
        }

        [NotNull]
        public static ILogger GetLogger<T>()
        {
            return GetLogger(typeof(T));
        }

        [NotNull]
        public static ILogger GetCurrentClassLogger([CallerFilePath] string callerFilePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(callerFilePath.Replace('\\', '/'));
            return GetLogger(className);
        }
    }

}
