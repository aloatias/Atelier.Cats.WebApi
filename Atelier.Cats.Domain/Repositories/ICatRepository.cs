using Atelier.Cats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atelier.Cats.Domain.Repositories
{
    public interface ICatRepository : IGenericRepository<Cat>
    {
        Task<Cat> FindByAtelierIdAsync(string id);
        Task<Tuple<Cat, Cat>> GetContendersAsync();
        Task<IEnumerable<Cat>> GetWinnersAsync();
    }
}
