namespace AdoPsiak.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; }
        public required string Breed { get; set; }
        public required string Localization { get; set; }
        public Genus Genus { get; set; }
        public Gender Gender { get; set; }
    }

    public enum Genus
    {
        Cat,
        Dog
    }

    public enum Gender
    {
        Male,
        Female,
    }
}
