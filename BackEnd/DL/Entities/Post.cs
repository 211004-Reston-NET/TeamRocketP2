using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Post
    {
        public Post()
        {
            Replies = new HashSet<Reply>();
        }

        public string PostText { get; set; }
        public string DateCreated { get; set; }
        public int UserId { get; set; }
        public int ForumId { get; set; }
        public int PostId { get; set; }

        public virtual Forum Forum { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
    }
}
