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

        public async Task<Dictionary<int, int>> GetNumberOfStapani()
        {
            List<Animal> AnimalList = await _context.Animals.ToListAsync();
            List<Stapan> StapanList = await _context.Stapani.ToListAsync();

            var ls = from animal in AnimalList
                     join stapan in StapanList
                     on animal.Id equals stapan.AnimalId
                     group animal by animal.Id into human
                     select new
                     {
                         AnimalName = human.Key,
                         NrOfStapani = human.Count()
                     };

            Dictionary<int, int> dict =
            new Dictionary<int, int>();

            foreach (var el in ls)
            {
                dict.Add(el.AnimalName, el.NrOfStapani);
            }

            return dict;
        }
      
    }
}