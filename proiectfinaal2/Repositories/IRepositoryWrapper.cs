using proiectfinaal2.Repositories;
using System.Threading.Tasks;

namespace proiectfinaal2.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        ISessionTokenRepository SessionToken { get; }

        Task SaveAsync();
    }
}
