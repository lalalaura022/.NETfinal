using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace proiectfinaal2.Models.entities2
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
