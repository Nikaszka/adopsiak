using Microsoft.EntityFrameworkCore;

namespace AdoPsiak.Dto
{
    public class MonetarySupportDto
    {
        public string? Name { get; set; }

        [Precision(16, 2)]
        public required decimal Value { get; set; }
    }
}
