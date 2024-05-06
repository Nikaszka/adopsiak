using Microsoft.EntityFrameworkCore;
using System;

namespace AdoPsiak.Entities
{
    public class MonetarySupport
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [Precision(16,2)]
        public required decimal Value { get; set; }
        public required DateTime Date { get; set; }
    }
}
