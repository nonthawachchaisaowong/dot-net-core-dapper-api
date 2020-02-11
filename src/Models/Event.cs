using Dapper.Contrib.Extensions;
using System;

namespace EventTracker.Models
{
    [Table("Event")]
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public int EventLocationId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
    }
}
