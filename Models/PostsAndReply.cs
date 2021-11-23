namespace Models
{
    public class PostsAndReply
    {
        public int PostId { get; set; }
        public int ReplyId { get; set; }
        public int PostReplyId { get; set; }

        public Post Post { get; set; }
        public Reply Reply { get; set; }
    }
}