namespace AdoPsiak.Entities
{
    public class ContactForm
    {
        public int Id { get; set; }
        public required string Topic { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string EmailAddress { get; set; }
        public required string PhoneNumber { get; set; }
        public required string MessageContent { get; set; }
        public MessageStatus MessageStatus { get; set; }     //dla administratora
        public DateTime SendingDate { get; set; }

    }

    public enum MessageStatus
    {
        Read,
        Unread
    }
}
