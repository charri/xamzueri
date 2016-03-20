using System;
using Newtonsoft.Json;

namespace XamZueri.App.Models
{
    public class StreamItem
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateSort { get; set; }

        public DateTime DateCreated { get; set; }

        public string Url { get; set; }

        [JsonProperty("odata.type")]
        public string Type { get; set; }
    }
}