using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamZueri.App.Models;

namespace XamZueri.App.Services
{
    public interface IODataNewsItemsService
    {
        Task<IEnumerable<NewsItem>> Next(int skip);
        Task<NewsItem> Single(Guid id);
    }
}