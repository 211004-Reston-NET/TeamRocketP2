using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Forum
    {
        public Forum()
        {
            Posts = new HashSet<Post>();
        }

        public string TopicName { get; set; }
        public string DateCreated { get; set; }
        public int CreatorId { get; set; }
        public int AmountOfPosts { get; set; }
        public int ForumId { get; set; }

        public virtual User Creator { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
