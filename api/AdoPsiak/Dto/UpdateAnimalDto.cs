using AdoPsiak.Entities;

namespace AdoPsiak.Dto
{
    public class UpdateAnimalDto
    {
        public required string Name { get; set; }
        public required string Age { get; set; }
        public required string Breed { get; set; }
        public required string Localization { get; set; }
        public int Genus { get; set; }
        public int Gender { get; set; }
        public int Status { get; set; } //dla administratora

        //public AnimalPhoto? AnimalPhoto { get; set; }
        //public Guid? AnimalPhotoId { get; set; }
        public bool ChildFriendly { get; set; } 
        public bool CatFriendly { get; set; }
        public bool DogFriendly { get; set; }
        public bool LikesToPlay { get; set; }
        public bool LikesToCuddle { get; set; }
        public bool DoesntLikeShelter { get; set; }
        public required string Description { get; set; }
    }
}
