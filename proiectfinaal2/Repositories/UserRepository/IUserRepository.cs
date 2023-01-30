using proiectfinaal2.Models.entities;
using proiectfinaal2.Repositories.GenericRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace proiectfinaal2.Repositories
{
    public interface IUserRepository: IGenericRepository<User>
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetAllUsersByEmail(string email);
        Task<User> GetByIdWithRoles(int Id);
    }
}
