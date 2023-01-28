using Microsoft.EntityFrameworkCore;
using proiectfinaal2.data;
using proiectfinaal2.Entities;
using proiectfinaal2.Repositories.GenericRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectfinaal2.Repositories.AnimalRepository
{
    public class AnimalRepository : GenericRepository<Animal>, IAnimalRepository
    {
        public AnimalRepository(Context context) : base(context) { }

        public async Task<List<Animal>> AllAnimalsWithAddress()
        {
            return await _context.Animals.Include(a => a.Address).ToListAsync();
        }
        public async Task<Animal> GetByIdWithAddress(int id)
        {
            return await _context.Animals.Include(a => a.Address).Where(a => a.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Animal> GetByDenumire(string denumire)
        {
            return await _context.Animals.Where(a => a.Denumire.Equals(denumire)).FirstOrDefaultAsync();
        }
    }
}