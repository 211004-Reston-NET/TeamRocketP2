using System.Collections.Generic;

namespace Models
{
    public class Event
    {
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public string Location { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public int EventId { get; set; }

        public virtual List<Invite> Invites { get; set; }
    }
}