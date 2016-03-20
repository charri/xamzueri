using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamZueri.App.Models;

namespace XamZueri.App.Services
{
    public interface IODataStreamItemsService
    {
        Task<IEnumerable<StreamItem>> Next(int skip);

        Task<StreamItem> Single(Guid id);
    }
}
