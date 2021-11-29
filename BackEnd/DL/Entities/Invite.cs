using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Invite
    {
        public int UserId { get; set; }
        public string EmailRecipient { get; set; }
        public int EventId { get; set; }
        public int InviteId { get; set; }

        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
    }
}
