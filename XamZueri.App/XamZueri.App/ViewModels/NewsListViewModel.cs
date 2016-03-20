using System.Collections.Generic;
using System.Threading.Tasks;
using XamZueri.App.Models;
using XamZueri.App.Services;

namespace XamZueri.App.ViewModels
{
    public class NewsListViewModel
        : AbstractListViewModel<NewsItem>
    {
        private readonly IODataNewsItemsService _newsItemsService;

        public NewsListViewModel(IODataNewsItemsService newsItemsService)
        {
            _newsItemsService = newsItemsService;
        }

        protected override Task<IEnumerable<NewsItem>> NextItems(int skip)
        {
            return _newsItemsService.Next(skip);
        }
    }
}