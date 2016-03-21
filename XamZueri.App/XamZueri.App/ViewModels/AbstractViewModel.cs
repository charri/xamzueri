using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using XamZueri.App.Services;
using XamZueri.App.Utils;

namespace XamZueri.App.ViewModels
{
    public abstract class AbstractViewModel
        : MvxViewModel
    {
        private static readonly ILogger Log = LogManager.GetCurrentClassLogger();

        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                SetProperty(ref _isBusy, value);
            }
        }

        protected IDisposable BeginBusyScope()
        {
            IsBusy = true;
            return new BusyScope(this);
        }

        class BusyScope : IDisposable
        {
            private readonly AbstractViewModel _viewModel;

            public BusyScope(AbstractViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public void Dispose()
            {
                _viewModel.IsBusy = false;
            }
        }

        protected void SetupCanExecuteDependency(string propertyName, params Func<ICommand>[] dependentCommands)
        {
            PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName != propertyName) return;

                foreach (var dependentCommand in dependentCommands)
                {
					var mvxcommand = dependentCommand.Invoke() as MvxCommandBase;

					mvxcommand?.RaiseCanExecuteChanged();
                }
            };
        }

        private bool _hasContent = true;
        public bool HasContent
        {
            get { return _hasContent; }
            set
            {
                _hasContent = value;
                RaisePropertyChanged(() => HasContent);
            }
        }

        public ICommand GoBackCommand
        {
            get { return new MvxCommand(() => Close(this)); }
        }

        internal Task StartTask;

        public override async void Start()
        {
            base.Start();

            try
            {
                StartTask = StartAsync();
                await StartTask;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        protected virtual Task StartAsync()
        {
            return Task.FromResult(0);
        }
    }
}
