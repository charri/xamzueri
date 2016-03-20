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
    public class ODataStreamItemsService
        : ODataService<StreamItem>, IODataStreamItemsService
    {

        public ODataStreamItemsService(HttpMessageHandler handler) : base(handler)
        {
        }

        public async Task<IEnumerable<StreamItem>> Next(int skip)
        {
            var builder =
                new ODataRequestBuilder<StreamItem>(Settings.Default.Host)
                    .Skip(skip).OrderBy("DateSort", "desc");

            return await GetItemsAsync(builder.Request);
        }

        public async Task<StreamItem> Single(Guid id)
        {
            var builder =
                new ODataRequestBuilder<StreamItem>(Settings.Default.Host)
                    .Single(id);

            return await GetSingleAsync(builder.Request);
        }

        
    }
}
