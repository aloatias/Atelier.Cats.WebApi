using Atelier.Cats.Application.Interfaces;
using Atelier.Cats.Application.Models;
using Atelier.Cats.Contracts;
using Atelier.Cats.Domain.Entities;
using Atelier.Cats.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Atelier.Cats.Application.Services
{
    public class ChallengeService : IChallengeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateGeneratorService _dateGeneratorService;

        public ChallengeService(
            IUnitOfWork unitOfWork,
            IDateGeneratorService dateGeneratorService)
        {
            _unitOfWork = unitOfWork;
            _dateGeneratorService = dateGeneratorService;
        }

        public async Task<IAtelierResponse<Guid>> AddAsync(ChallengeResultDto challengeResultDto)
        {
            var challenge = new Challenge
            {
                ChallengerOneId = challengeResultDto.ChallengerOneId,
                ChallengerTwoId = challengeResultDto.ChallengerTwoId,
                WinnerId = challengeResultDto.WinnerId,
                VoteDate = _dateGeneratorService.GetDate()
            };

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
