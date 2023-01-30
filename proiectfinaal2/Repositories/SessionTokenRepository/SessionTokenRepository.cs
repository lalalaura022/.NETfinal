using Microsoft.EntityFrameworkCore;
using proiectfinaal2.data;
using proiectfinaal2.Models.entities2;
using proiectfinaal2.Repositories.GenericRepository;
using System.Threading.Tasks;

namespace proiectfinaal2.Repositories
{
    public class SessionTokenRepository : GenericRepository<SessionToken>, ISessionTokenRepository
    {
        public SessionTokenRepository(Context context) : base(context) { }

        public async Task<SessionToken> GetByJTI(string jti)
        {
            return await _context.SessionTokens.FirstOrDefaultAsync(t => t.Jti.Equals(jti));
        }
    }
}
