using System.Collections.Generic;

namespace Models
{
    public class Reply
    {
        public string ReplyText { get; set; }
        public string DateCreated { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int ReplyId { get; set; }

        public User User { get; set; }
        public List<PostsAndReply> PostsAndReplies { get; set; } 
    }
}