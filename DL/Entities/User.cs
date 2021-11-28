using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class User
    {
        public User()
        {
            Forums = new HashSet<Forum>();
            Invites = new HashSet<Invite>();
            Posts = new HashSet<Post>();
            Replies = new HashSet<Reply>();
        }

        public string UserName { get; set; }
        public string UserPass { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public string NameOfUser { get; set; }

        public virtual ICollection<Forum> Forums { get; set; }
        public virtual ICollection<Invite> Invites { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
    }
}
