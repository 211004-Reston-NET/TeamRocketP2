using System.Collections.Generic;

namespace Models
{
    public class Post
    {
        public string PostText { get; set; }
        public string DateCreated { get; set; }
        public int UserId { get; set; }
        public int ForumId { get; set; }
        public int PostId { get; set; }

        public Forum Forum { get; set; }
        public User User { get; set; }
        public List<PostsAndReply> PostsAndReplies { get; set; }
    }
}