using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using MvvmCross.Core;
using MvvmCross.Core.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Platform.Core;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform.Platform;
using NUnit.Framework;
using XamZueri.App.ViewModels;

namespace XamZueri.App.Tests.Mvx
{
    public abstract class MvxTest
    {
        private IMvxIoCProvider _ioc;

        protected IMvxIoCProvider Ioc
        {
            get { return _ioc; }
        }

        protected Mock<MockDispatcher> MockDispatcher;
        protected Mock<MockTrace> MockTrace;

        [SetUp]
        public void Setup()
        {
            ClearAll();
        }

        protected virtual void ClearAll()
        {
            // fake set up of the IoC
            MvxSingleton.ClearAllSingletons();
            var withInject = new MvxPropertyInjectorOptions()
            {
                InjectIntoProperties = MvxPropertyInjection.MvxInjectInterfaceProperties,
                ThrowIfPropertyInjectionFails = true
            };
            var options = new MvxIocOptions { PropertyInjectorOptions = withInject };
            _ioc = MvxSimpleIoCContainer.Initialize(options);
            _ioc.RegisterSingleton(_ioc);
            InitializeTrace();
            InitializeSingletonCache();
            InitializeMvxSettings();
            MvxTrace.Initialize();
            AdditionalSetup();
        }

        protected virtual void InitializeTrace()
        {
            MockTrace = new Mock<MockTrace>(MockBehavior.Loose) {CallBase = true};

            Ioc.RegisterSingleton<IMvxTrace>(MockTrace.Object);
        }

        private static void InitializeSingletonCache()
        {
            MvxSingletonCache.Initialize();
        }

        protected virtual void InitializeMvxSettings()
        {
            Ioc.RegisterSingleton<IMvxSettings>(new MvxSettings());
        }

        protected virtual void AdditionalSetup()
        {
            MockDispatcher = new Mock<MockDispatcher>(MockBehavior.Loose) { CallBase = true };

            Ioc.RegisterSingleton<IMvxViewDispatcher>(MockDispatcher.Object);

            Ioc.RegisterType<HttpMessageHandler>(() => new HttpClientHandler());
        }

        protected async Task<TViewModel> ViewModelWithLifecycleAsync<TViewModel>(
            Action<TViewModel> initFunc = null,
            IDictionary<string, string> initBundle = null
            )
            where TViewModel : class, IMvxViewModel
        {
            var viewModel = Ioc.IoCConstruct<TViewModel>();

            // all init methods are called in mvvmcross on navigation to viewmodel
            viewModel.Init(initBundle == null ? null : new MvxBundle(initBundle));

            initFunc?.Invoke(viewModel);

            viewModel.Start();

            var abstractViewModel = viewModel as AbstractViewModel;

            if (abstractViewModel != null)
            {
                await abstractViewModel.StartTask;
            }

            return viewModel;
        }
    }
}
