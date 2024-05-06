using AdoPsiak.Entities;

namespace AdoPsiak.Dto
{
    public class NewAnimalDto
    {
       
        public required string Name { get; set; }
        public int Age { get; set; }
        public required string Breed { get; set; }
        public required string Localization { get; set; }
        public Genus Genus { get; set; }
        public Gender Gender { get; set; }
        

    }

}
