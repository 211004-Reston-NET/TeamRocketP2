using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Reply
    {
        public string ReplyText { get; set; }
        public string DateCreated { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int ReplyId { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
