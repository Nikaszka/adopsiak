using System.ComponentModel.DataAnnotations.Schema;

namespace AdoPsiak.Entities
{
    public class AnimalPhoto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Animal Animal { get; set; }
        public required string ImageContent { get; set; }
        public required string ContentType { get; set; }
    }
}
