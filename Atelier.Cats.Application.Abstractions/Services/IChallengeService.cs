using Atelier.Cats.Contracts;
using System;
using System.Threading.Tasks;

namespace Atelier.Cats.Application.Abstractions.Services
{
    public interface IChallengeService
    {
        Task<ChallengeDto> AddAsync(ChallengeCreationDto challenge);
        Task<int> CountAsync();
        Task<ChallengeDto> FindAsync(Guid id);
    }
}
