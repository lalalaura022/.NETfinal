using Microsoft.AspNetCore.Identity;
using proiectfinaal2.Models.entities;

namespace proiectfinaal2.Models.entities2
{
    public class UserRole : IdentityUserRole<int>
    {
        public Role Role { get; set; }
        public User User { get; set; }
    }
}
