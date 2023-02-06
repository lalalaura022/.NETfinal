using proiectfinaal2.Entities;
using proiectfinaal2.Repositories.GenericRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace proiectfinaal2.Repositories.AnimalRepository
{
    public interface IAnimalRepository : IGenericRepository<Animal>
    {
        Task<Animal> GetByDenumire(string Denumire);
        Task<List<Animal>> AllAnimalsWithAddress();
        Task<Animal> GetByIdWithAddress(int id);
        Task<Dictionary<int, int>> GetNumberOfStapani();
    }
}
