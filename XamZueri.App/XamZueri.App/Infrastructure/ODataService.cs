using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XamZueri.App.Infrastructure
{
    public abstract class ODataService<TEntity>
    {
        private readonly HttpMessageHandler _handler;

        protected ODataService(HttpMessageHandler handler)
        {
            _handler = handler;
        }

        public async Task<IEnumerable<TEntity>> GetItemsAsync(HttpRequestMessage requestMessage)
        {
            var client = new HttpClient(_handler, false);

            var response = await client.SendAsync(requestMessage);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ODataWrapper>(content);

            return result.Value;
        }

        public async Task<TEntity> GetSingleAsync(HttpRequestMessage requestMessage)
        {
            var client = new HttpClient(_handler, false);

            var response = await client.SendAsync(requestMessage);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TEntity>(content);
        }

        public class ODataWrapper
        {
            public IList<TEntity> Value { get; set; } 
        }
    }
}
