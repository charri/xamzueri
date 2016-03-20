using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamZueri.App.Models;
using XamZueri.App.Services;

namespace XamZueri.App.Infrastructure
{

    public class MeetupService
        : IMeetupService
    {

        private readonly HttpMessageHandler _handler;

        public MeetupService(HttpMessageHandler handler)
        {
            _handler = handler;
        }

        public async Task<Meetup> GetDetailsAsync(string meetupId)
        {
            var client = new HttpClient(_handler, false);

            var response = await client.GetAsync(string.Format(Settings.Default.MeetupApi, meetupId));

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Meetup>(content);
        }
    }
}