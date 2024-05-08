namespace AdoPsiak.Dto
{
    public class NewContactFormDto
    {
        public required string Topic { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required string EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public required string MessageContent { get; set; }

    }


}
