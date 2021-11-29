using System.Collections.Generic;

namespace Models
{
    public class Forum
    {
        public string TopicName { get; set; }
        public string DateCreated { get; set; }
        public int CreatorId { get; set; }
        public int AmountOfPosts { get; set; }
        public int ForumId { get; set; }

        public User Creator { get; set; }
        public List<Post> Posts { get; set; }
    }
}