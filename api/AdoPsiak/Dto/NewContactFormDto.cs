namespace AdoPsiak.Dto
{
    public class NewContactFormDto
    {
        public required string Topic { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string EmailAddress { get; set; }
        public required string PhoneNumber { get; set; }
        public required string MessageContent { get; set; }

    }


}
