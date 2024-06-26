﻿namespace AdoPsiak.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Age { get; set; }
        public required string Breed { get; set; }
        public required string Localization { get; set; }
        public Genus Genus { get; set; }
        public Gender Gender { get; set; }
        public List<AdoptionForm> AdoptionForms { get; set; } = null!;
        public AnimalStatus Status { get; set; } = AnimalStatus.ForAdoption; //dla administratora

        public AnimalPhoto? AnimalPhoto { get; set; }
        public Guid? AnimalPhotoId { get; set; }
        public bool ChildFriendly { get; set; } = true;
        public bool CatFriendly { get; set; } = true;
        public bool DogFriendly { get; set; } = true;
        public bool LikesToPlay { get; set; } = true;
        public bool LikesToCuddle { get; set; } = true;
        public bool DoesntLikeShelter { get; set; } = true;
        public required string Description { get; set; }
    }

    public enum Genus
    {
        Cat,
        Dog
    }

    public enum Gender
    {
        Male,
        Female
    }
    public enum AnimalStatus
    {
        ForAdoption,
        Adopted
    }
}
