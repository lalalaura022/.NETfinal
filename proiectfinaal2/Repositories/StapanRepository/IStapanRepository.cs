using proiectfinaal2.Entities;
using proiectfinaal2.Repositories.GenericRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace proiectfinaal2.Repositories.StapanRepository
{
    public interface IStapanRepository : IGenericRepository<Stapan>
    {
        Task<Stapan> GetByName(string Name);
    }
}


