using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamZueri.App.Services;
using XamZueri.App.Utils;

namespace XamZueri.App.Controls
{
    public class InfiniteListView
        : ListView
    {
        private static readonly ILogger Log = LogManager.GetCurrentClassLogger();

        public static readonly BindableProperty LoadMoreCommandProperty = BindableProperty.Create(nameof(LoadMoreCommand), typeof(ICommand), typeof(InfiniteListView), default(ICommand));

        public ICommand LoadMoreCommand
        {
            get { return (ICommand)GetValue(LoadMoreCommandProperty); }
            set { SetValue(LoadMoreCommandProperty, value); }
        }

        public static readonly BindableProperty SelectedItemCommandProperty = BindableProperty.Create(nameof(SelectedItemCommand), typeof(ICommand), typeof(InfiniteListView), default(ICommand));

        public ICommand SelectedItemCommand
        {
            get { return (ICommand)GetValue(SelectedItemCommandProperty); }
            set { SetValue(SelectedItemCommandProperty, value); }
        }

        public static readonly BindableProperty LoadMoreOffsetProperty = BindableProperty.Create(nameof(LoadMoreOffset), typeof(int), typeof(InfiniteListView), 1, BindingMode.OneWay, ValidateValue);

        private static bool ValidateValue(BindableObject bindable, object value)
        {
            var v = (int) value;

            return v >= 0;
        }

        public int LoadMoreOffset
        {
            get { return (int)GetValue(LoadMoreOffsetProperty); }
            set { SetValue(LoadMoreOffsetProperty, value); }
        }

        public InfiniteListView()
            : base(ListViewCachingStrategy.RecycleElement)
        {
            ItemAppearing += InfiniteListView_ItemAppearing;
            ItemSelected += InfiniteListView_ItemSelected;
        }

        private void InfiniteListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            SelectedItem = null;

            if (SelectedItemCommand != null && SelectedItemCommand.CanExecute(e.SelectedItem))
                SelectedItemCommand.Execute(e.SelectedItem);
        }

        private void InfiniteListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var items = ItemsSource as IList;

            if (items == null)
            {
                Log.Warn("ItemsSource needs to be of type IList, otherwise performance suffers to great");
                return;
            }

            if (LoadMoreCommand == default(ICommand)) return;

            if (e.Item == items[items.Count - LoadMoreOffset] && LoadMoreCommand.CanExecute(e.Item))
            {
                LoadMoreCommand.Execute(e.Item);
            }
        }
    }
}
