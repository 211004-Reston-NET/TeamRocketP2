using System.Collections.Generic;

namespace Models
{
    public class Event
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Location { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public int EventId { get; set; }

        public virtual List<Invite> Invites { get; set; }
    }
}