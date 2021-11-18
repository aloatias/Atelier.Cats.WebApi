using Atelier.Cats.Application.Dtos;
using System;
using System.Threading.Tasks;

namespace Atelier.Cats.Application.Interfaces
{
    public interface IChallengeService
    {
        Task<Guid> AddAsync(ChallengeCreationDto challenge);
        Task<int> CountAsync();
        Task<ChallengeDetailsDto> FindAsync(Guid id);
    }
}
