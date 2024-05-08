namespace AdoPsiak.Entities
{
    public class AdoptionForm
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string EmailAddress { get; set; }
        public required string PhoneNumber { get; set;}
        public required string StreetName { get; set; }
        public string? ApartmentNumber { get; set; }
        public required string City { get; set; }
        public required string Voivodeship { get; set; } //województwo
        public required string ZipCode {  get; set; } //kod pocztowy
        public required Animal SelectedAnimal{ get; set;}
        public required string AboutEnviroment { get; set; }
        public required string AboutExperienceWithAnimals { get; set; }
        public required string AboutOtherAnimals { get; set; }
        public required string AboutResponsibility { get; set; }
        public FormStatus FormStatus { get; set; } = FormStatus.InProgress;   //dla administratora
        public DateTime SendingDate { get; set; }


    }

    public enum FormStatus
    {
        Accepted,
        Rejected,
        InProgress
    }
}
