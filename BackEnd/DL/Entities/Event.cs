using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Event
    {
        public Event()
        {
            Invites = new HashSet<Invite>();
        }

        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public string Location { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public int EventId { get; set; }

        public virtual ICollection<Invite> Invites { get; set; }
    }
}
