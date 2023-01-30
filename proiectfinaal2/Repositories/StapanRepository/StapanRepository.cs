using Microsoft.EntityFrameworkCore;
using proiectfinaal2.data;
using proiectfinaal2.Entities;
using proiectfinaal2.Repositories.AnimalRepository;
using proiectfinaal2.Repositories.GenericRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectfinaal2.Repositories.StapanRepository
{
    public class StapanRepository : GenericRepository<Stapan>, IStapanRepository
    {
        public StapanRepository(Context context) : base(context) { }

        public async Task<Stapan> GetByName(string name)
        {
            return await _context.Stapani.Where(s => s.Name.Equals(name)).FirstOrDefaultAsync();
        }
    }
}
