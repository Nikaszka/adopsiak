using AdoPsiak.Entities;

namespace AdoPsiak.Dto
{
    public class NewAnimalDto
    {
       
        public required string Name { get; set; }
        public required string Age { get; set; }
        public required string Breed { get; set; }
        public required string Localization { get; set; }
        public Genus Genus { get; set; }
        public Gender Gender { get; set; }
        public bool ChildFriendly { get; set; } = true;
        public bool CatFriendly { get; set; } = true;
        public bool DogFriendly { get; set; } = true;
        public bool LikesToPlay { get; set; } = true;
        public bool LikesToCuddle { get; set; } = true;
        public bool DoesntLikeShelter { get; set; } = true;
        public required string Description { get; set; }
        public AnimalStatus Status { get; set; } = AnimalStatus.ForAdoption; //dla administratora

    }

}
