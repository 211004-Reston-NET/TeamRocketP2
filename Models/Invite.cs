namespace Models
{
    public class Invite
    {
        public int UserId { get; set; }
        public string EmailRecipient { get; set; }
        public int EventId { get; set; }
        public int InviteId { get; set; }

        public Event Event { get; set; }
        public User User { get; set; }
    }
}