using proiectfinaal2.Models.entities2;
using proiectfinaal2.Repositories.GenericRepository;
using System.Threading.Tasks;

namespace proiectfinaal2.Repositories
{
    public interface ISessionTokenRepository : IGenericRepository<SessionToken>
    {
        Task<SessionToken> GetByJTI(string jti);
    }
}
