using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proiectfinaal2.data;
using proiectfinaal2.Models.entities;
using proiectfinaal2.Repositories;
using proiectfinaal2.Repositories.GenericRepository;

namespace proiectfinaal2.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context) { }
        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdWithRoles(int id)
        {
            return await _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync(u => u.Id.Equals(id));
        }

        public async Task<User> GetAllUsersByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
