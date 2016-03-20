using System;
using System.Diagnostics;
using System.Net.Http;
using ModernHttpClient;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using Xamarin.Forms.Xaml;
using XamZueri.App.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamZueri.App
{
    public class AppStart : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.RegisterType<HttpMessageHandler>(() => new NativeMessageHandler());

            RegisterAppStart<MainViewModel>();
        }

        public static void OnUnhandledException(Exception exception, bool isTerminating)
        {
            Debugger.Break();
        }
    }
}