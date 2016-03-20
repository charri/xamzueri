using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamZueri.App.Models;

namespace XamZueri.App.Services
{
    public interface IODataEventItemsService
    {
        Task<IEnumerable<EventItem>> Next(int skip);
        Task<EventItem> Single(Guid id);
    }
}