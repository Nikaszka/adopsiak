using Microsoft.AspNetCore.Identity;

namespace AdoPsiak.Entities
{
    public class Admin : IdentityUser
    {
        public string? Name { get; set; }
    }
}
