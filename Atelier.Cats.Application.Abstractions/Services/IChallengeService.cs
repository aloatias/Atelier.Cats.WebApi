﻿using Atelier.Cats.Contracts;
using System;
using System.Threading.Tasks;

namespace Atelier.Cats.Application.Abstractions.Services
{
    public interface IChallengeService
    {
        Task<ChallengeDetailsDto> AddAsync(ChallengeCreationDto challenge);
        Task<int> CountAsync();
        Task<ChallengeDetailsDto> FindAsync(Guid id);
    }
}
