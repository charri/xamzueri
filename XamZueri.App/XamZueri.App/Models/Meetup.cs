

using Newtonsoft.Json;

namespace XamZueri.App.Models
{
    public class Meetup
    {
        [JsonProperty("yes_rsvp_count")]
        public int Attending { get; set; }
    }
}