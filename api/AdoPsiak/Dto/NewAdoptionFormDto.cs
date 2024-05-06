using AdoPsiak.Entities;

namespace AdoPsiak.Dto
{
    public class NewAdoptionFormDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string EmailAddress { get; set; }
        public required Address Address { get; set; }
        public required int SelectedAnimalId { get; set; }
        public required Answer Answer { get; set; }

    }

    public class Address
    {
        public required string PhoneNumber { get; set; }
        public required string StreetName { get; set; }
        public string? ApartmentNumber { get; set; }
        public required string City { get; set; }
        public required string Voivodeship { get; set; } //województwo
        public required string ZipCode { get; set; } //kod pocztowy
    }
    public class Answer
    {
        public required string AboutEnviroment { get; set; }
        public required string AboutExperienceWithAnimals { get; set; }
        public required string AboutOtherAnimals { get; set; }
        public required string AboutResponsibility { get; set; }

    }
}
