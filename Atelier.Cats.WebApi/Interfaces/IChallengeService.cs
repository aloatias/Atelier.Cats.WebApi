using Atelier.Cats.DataAccess.Entities;
using Atelier.Cats.WebApi.Dtos;
using System.Threading.Tasks;

namespace Atelier.Cats.WebApi.Interfaces
{
    public interface IChallengeService
    {
        Task<Challenge> AddAsync(ChallengeResultDto challengeResultDto);
    }
}
