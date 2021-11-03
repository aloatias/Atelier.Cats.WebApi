using Atelier.Cats.Application.Abstractions.Models;
using Atelier.Cats.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Atelier.Cats.Application.Abstractions.Services
{
    public interface IChallengeService
    {
        Task<IAtelierResponse<Guid>> AddAsync(Challenge challenge);
        Task<IAtelierResponse<Challenge>> FindAsync(Guid id);
        Task<IAtelierResponse<int>> CountAsync();
    }
}
