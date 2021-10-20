using Atelier.Cats.DataAccess.Entities;
using System.Threading.Tasks;

namespace Atelier.Cats.DataAccess.Interfaces
{
    public interface IChallengeRepository : IGenericRepository<Challenge>
    {
        Task GetResultsAsync();
    }
}
