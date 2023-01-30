using proiectfinaal2.data;
using proiectfinaal2.Repositories;
using System.Threading.Tasks;

namespace proiectfinaal2.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly Context _context;
        private IUserRepository _user;
        private ISessionTokenRepository _sessionToken;
        public RepositoryWrapper(Context context)
        {
            _context = context;
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null) _user = new UserRepository(_context);
                return _user;
            }
        }

        public ISessionTokenRepository SessionToken
        {
            get
            {
                if (_sessionToken == null) _sessionToken = new SessionTokenRepository(_context);
                return _sessionToken;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
