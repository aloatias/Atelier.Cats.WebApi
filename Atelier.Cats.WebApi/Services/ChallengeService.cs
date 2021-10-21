using Atelier.Cats.DataAccess.Entities;
using Atelier.Cats.DataAccess.Interfaces;
using Atelier.Cats.WebApi.Dtos;
using Atelier.Cats.WebApi.Interfaces;
using System.Threading.Tasks;

namespace Atelier.Cats.WebApi.Services
{
    public class ChallengeService : IChallengeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateGenerator _dateGenerator;

        public ChallengeService(
            IUnitOfWork unitOfWork,
            IDateGenerator dateGenerator)
        {
            _unitOfWork = unitOfWork;
            _dateGenerator = dateGenerator;
        }
        
        public async Task<Challenge> AddAsync(ChallengeResultDto challengeResultDto)
        {
            var challenge = new Challenge
            {
                ChallengerOneId = challengeResultDto.ChallengerOneId,
                ChallengerTwoId = challengeResultDto.ChallengerTwoId,
                WinnerId = challengeResultDto.WinnerId,
                VoteDate = _dateGenerator.GetDate()
            };

            var createdChallenge = await _unitOfWork.ChallengeRepository.AddAsync(challenge);
            await _unitOfWork.CommitAsync();

            return createdChallenge;
        }
    }
}
