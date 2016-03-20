using System;
using System.Diagnostics;
using Android.App;
using Android.OS;
using Android.Runtime;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

namespace XamZueri.App.Droid.PlatformServices
{
    public class MvxFormsActivityLifecycleCallbacks
        : Java.Lang.Object, Application.IActivityLifecycleCallbacks
    {
        private static readonly Lazy<MvxFormsActivityLifecycleCallbacks> _instance = new Lazy<MvxFormsActivityLifecycleCallbacks>(() => new MvxFormsActivityLifecycleCallbacks());

        public static MvxFormsActivityLifecycleCallbacks Instance => _instance.Value;


        protected MvxFormsActivityLifecycleCallbacks()
        {
            
        }

        private static void OnLifetimeEvent(Activity activity,
                                           Action<IMvxAndroidActivityLifetimeListener, Activity> report)
        {
            if (!Mvx.CanResolve<IMvxAndroidActivityLifetimeListener>())
                Debugger.Break();

            var activityTracker = Mvx.Resolve<IMvxAndroidActivityLifetimeListener>();
            
            report(activityTracker, activity);
        }

        protected MvxFormsActivityLifecycleCallbacks(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
            
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            OnLifetimeEvent(activity, (l, a) => l.OnCreate(a));
        }

        public void OnActivityDestroyed(Activity activity)
        {
            OnLifetimeEvent(activity, (l, a) => l.OnDestroy(a));
        }

        public void OnActivityPaused(Activity activity)
        {
            OnLifetimeEvent(activity, (l, a) => l.OnPause(a));
        }

        public void OnActivityResumed(Activity activity)
        {
            OnLifetimeEvent(activity, (l, a) => l.OnResume(a));
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
            
        }

        public void OnActivityStarted(Activity activity)
        {
            OnLifetimeEvent(activity, (l, a) => l.OnStart(a));
        }

        public void OnActivityStopped(Activity activity)
        {
            OnLifetimeEvent(activity, (l, a) => l.OnStop(a));
        }
    }
}