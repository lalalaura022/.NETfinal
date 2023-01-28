using Microsoft.AspNetCore.Identity;
using proiectfinaal2.Models.entities2;
using System.Collections.Generic;

namespace proiectfinaal2.Models.entities
{
    public class User : IdentityUser<int>
    {
        public User() : base() { }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }

    }
}
