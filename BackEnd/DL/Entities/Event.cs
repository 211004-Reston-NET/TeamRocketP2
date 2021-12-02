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

        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Location { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public int EventId { get; set; }
        public string EndDate { get; set; }
        public string StartDate { get; set; }

        public virtual ICollection<Invite> Invites { get; set; }
    }
}
