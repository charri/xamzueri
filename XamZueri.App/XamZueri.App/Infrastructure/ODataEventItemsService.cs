using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamZueri.App.Models;
using XamZueri.App.Services;
using XamZueri.App.Utils;

namespace XamZueri.App.Infrastructure
{
    public class ODataEventItemsService
        : ODataService<EventItem>, IODataEventItemsService
    {
        public ODataEventItemsService(HttpMessageHandler handler) : base(handler)
        {
        }

        public async Task<IEnumerable<EventItem>> Next(int skip)
        {
            var builder =
                new ODataRequestBuilder<EventItem>(Settings.Default.Host)
                    .Skip(skip).OrderBy("DateSort", "desc");

            return await GetItemsAsync(builder.Request);
        }

        public async Task<EventItem> Single(Guid id)
        {
            var builder =
                new ODataRequestBuilder<StreamItem>(Settings.Default.Host)
                    .Single(id);

            return await GetSingleAsync(builder.Request);
        }
    }
}
