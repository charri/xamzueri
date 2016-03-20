using System;

namespace XamZueri.App.Models
{
    public class EventItem
        : StreamItem
    {
        public DateTime DateEvent { get; set; }

        public string MeetupId { get; set; }

        public string Speaker { get; set; }

        public string SpeakerHandle { get; set; }

        public string HeaderUrl { get; set; }
        
        public bool HasPhotos { get; set; }
    }
}