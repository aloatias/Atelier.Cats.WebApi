﻿using Atelier.Cats.Application.Abstractions.Models;
using Atelier.Cats.Application.Abstractions.Services;
using Atelier.Cats.Application.Models;
using Atelier.Cats.Domain.Entities;
using Atelier.Cats.Domain.Repositories;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Cats.Application.Services
{
    public class ChallengeService : IChallengeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChallengeService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IAtelierResponse<Guid>> AddAsync(Challenge challenge)
        {
            // Check conflict
            var challengeExist = await _unitOfWork.ChallengeRepository
                .ExistsAsync(x => x.ChallengerOneId == challenge.ChallengerOneId
                    && x.ChallengerTwoId == challenge.ChallengerTwoId
                || x.ChallengerTwoId == challenge.ChallengerOneId
                    && x.ChallengerOneId == challenge.ChallengerTwoId);

            if (challengeExist)
            {
                return new Conflict<Guid>("These cats have already faced each other");
            }

            // Check existence
            var contenderOne = await _unitOfWork.CatRepository.FindAsync(challenge.ChallengerOneId);
            var contenderTwo = await _unitOfWork.CatRepository.FindAsync(challenge.ChallengerTwoId);

            var sb = new StringBuilder();

            if (contenderOne is null)
            {
                sb.Append($"The cat { challenge.ChallengerOneId } doesn't exist \r\n");
            }

            if (contenderTwo is null)
            {
                sb.Append($"The cat { challenge.ChallengerTwoId } doesn't exist");
            }

            if (contenderOne is null
                || contenderTwo is null)
            {
                return new BadRequest<Guid>(sb.ToString());
            }

            var createdChallenge = await _unitOfWork.ChallengeRepository.AddAsync(challenge);
            await _unitOfWork.CommitAsync();

            return new Created<Guid>(createdChallenge.Id);
        }

        public async Task<IAtelierResponse<int>> CountAsync()
        {
            return new Ok<int>(await _unitOfWork.ChallengeRepository.CountAsync());
        }

        public async Task<IAtelierResponse<Challenge>> FindAsync(Guid id)
        {
            var challenge = await _unitOfWork.ChallengeRepository.FindAsync(id);
            if (challenge is null)
            {
                return new NoContent<Challenge>("The searched challenge wasn't found");
            }

            return new Ok<Challenge>(challenge);
        }
    }
}
