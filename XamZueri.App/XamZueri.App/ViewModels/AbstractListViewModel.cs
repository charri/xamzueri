using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using XamZueri.App.Models;
using XamZueri.App.Services;
using XamZueri.App.Utils;

namespace XamZueri.App.ViewModels
{
    public abstract class AbstractListViewModel<TItem>
        : AbstractViewModel
    {
        // ReSharper disable once StaticMemberInGenericType, acceptable for logging
        private static readonly ILogger Log = LogManager.GetCurrentClassLogger();

        public ObservableRangeCollection<TItem> Items { get; set; } = new ObservableRangeCollection<TItem>();

        private ICommand _refreshCommand;
        private ICommand _selectItemCommand;
        private ICommand _loadMoreCommand;


        public override void Start()
        {
			SetupCanExecuteDependency(nameof(IsBusy), () => LoadMoreCommand, () => RefreshCommand);
            base.Start();
        }

        protected override async Task StartAsync()
        {
            await base.StartAsync();
            await LoadMoreAsync();
        }

        public ICommand LoadMoreCommand
        {
            get { return _loadMoreCommand ?? (_loadMoreCommand = new MvxAsyncCommand(LoadMoreAsync, () => !IsBusy) ); }
        }

        private async Task LoadMoreAsync()
        {
            try
            {
                using (BeginBusyScope())
                {
                    var newItems = await NextItems(Items.Count);
                    Items.AddRange(newItems);
                }
            }
            catch (Exception ex)
            {
                // TODO: Tell user something happend
                Log.Error(ex);
            }
        }

        protected abstract Task<IEnumerable<TItem>> NextItems(int skip);

        public ICommand SelectedItemCommand
        {
            get { return _selectItemCommand ?? (_selectItemCommand = new MvxCommand<StreamItem>(ExecuteSelectItemCommand)); }
        }

        private void ExecuteSelectItemCommand(StreamItem item)
        {
            // navigate depending on type   
            if (item is NewsItem || (!string.IsNullOrEmpty(item.Type) && item.Type.EndsWith("NewsItem")))
            {
                ShowViewModel<WebViewViewModel>(new { url = item.Url, title = item.Title });
                return;
            }

            if (item is EventItem || (!string.IsNullOrEmpty(item.Type) && item.Type.EndsWith("EventItem")))
            {
                ShowViewModel<EventDetailViewModel>(new {id = item.Id});
                return;
            }
        }

        public ICommand RefreshCommand
        {
            get { return _refreshCommand ?? (_refreshCommand = new MvxAsyncCommand(RefreshAsync, () => !IsBusy)); }
        }

        public async Task RefreshAsync()
        {
            try
            {
                using (BeginBusyScope())
                {
                    var newItems = await NextItems(0);
                    Items.Clear();
                    Items.AddRange(newItems);
                }
            }
            catch (Exception ex)
            {
                // TODO: Tell user something happend
                Log.Error(ex);
            }
        }
    }
}
