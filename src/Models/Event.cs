using System;

namespace EventTracker.Models
{
    public class Event
    {
        public int Id { get; set; }
        public int EventLocationId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
    }
}
