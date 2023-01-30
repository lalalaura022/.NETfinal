using proiectfinaal2.Entities.DTOs;
using System.Threading.Tasks;

namespace proiectfinaal2.Services.UserServices
{
    public interface IUserServices
    {
        Task<bool> RegisterUserAsync(RegisterUserDTO dto);
        Task<string> LoginUser(LoginUserDTO dto);
    }
}
