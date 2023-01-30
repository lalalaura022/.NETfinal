using proiectfinaal2.Entities;
using proiectfinaal2.Repositories.GenericRepository;
using System.Threading.Tasks;

namespace proiectfinaal2.Repositories.MedicamentRepository
{
    public interface IMedicamentRepository : IGenericRepository<Medicament>
    {
        Task<Medicament> GetByDenumire(string Denumire);
    }
}
