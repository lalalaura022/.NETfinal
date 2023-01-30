using Microsoft.EntityFrameworkCore;
using proiectfinaal2.data;
using proiectfinaal2.Entities;
using proiectfinaal2.Repositories.GenericRepository;
using proiectfinaal2.Repositories.StapanRepository;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace proiectfinaal2.Repositories.MedicamentRepository
{
    public class MedicamentRepository : GenericRepository<Medicament>, IMedicamentRepository
    {
        public MedicamentRepository(Context context) : base(context) { }

        public async Task<Medicament> GetByDenumire(string denumire)
        {
            return await _context.Medicamente.Where(s => s.Denumire.Equals(denumire)).FirstOrDefaultAsync();
        }
    }
}
