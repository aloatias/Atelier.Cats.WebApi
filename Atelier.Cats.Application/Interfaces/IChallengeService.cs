using Atelier.Cats.Contracts;
using Atelier.Cats.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Atelier.Cats.Application.Interfaces
{
    public interface IChallengeService
    {
        Task<IAtelierResponse<Guid>> AddAsync(ChallengeResultDto challengeResultDto);
        Task<IAtelierResponse<Challenge>> FindAsync(Guid id);
        Task<IAtelierResponse<int>> CountAsync();
    }
}
