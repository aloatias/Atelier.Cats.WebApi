using Atelier.Cats.DataAccess.Entities;
using System;
using System.Threading.Tasks;

namespace Atelier.Cats.DataAccess.Interfaces
{
    public interface ICatRepository : IGenericRepository<Cat>
    {
        Task<Cat> FindByAtelierIdAsync(string id);
        Task<Tuple<Cat, Cat>> GetContendersAsync();
    }
}
