using Atelier.Cats.Contracts;
using Atelier.Cats.Domain.Entities;
using System.Threading.Tasks;

namespace Atelier.Cats.Services.Abstractions
{
    public interface IChallengeService
    {
        Task<Challenge> AddAsync(ChallengeResultDto challengeResultDto);
    }
}
