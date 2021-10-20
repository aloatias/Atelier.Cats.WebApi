using Atelier.Cats.DataAccess.Entities;
using System.Collections.Generic;

namespace Atelier.Cats.DataAccess.Interfaces
{
    public interface IChallengeRepository : IGenericRepository<Challenge>
    {
        IReadOnlyCollection<Challenge> GetResultsAsync();
    }
}
