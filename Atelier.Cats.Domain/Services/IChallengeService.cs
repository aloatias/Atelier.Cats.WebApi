using Atelier.Cats.Domain.Dtos;
using System;
using System.Threading.Tasks;

namespace Atelier.Cats.Domain.Services
{
    public interface IChallengeService
    {
        Task<ChallengeDetailsDto> AddAsync(ChallengeCreationDto challenge);
        Task<int> CountAsync();
        Task<ChallengeDetailsDto> FindAsync(Guid id);
    }
}
