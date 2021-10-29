using Atelier.Cats.Contracts;
using Atelier.Cats.Domain.Entities;
using Atelier.Cats.Domain.Repositories;
using Atelier.Cats.Services.Abstractions;
using System.Threading.Tasks;

namespace Atelier.Cats.Services
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

        public async Task<Challenge> AddAsync(ChallengeResultDto challengeResultDto)
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

            return createdChallenge;
        }
    }
}
