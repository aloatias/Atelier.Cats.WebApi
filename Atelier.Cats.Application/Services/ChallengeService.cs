using Atelier.Cats.Application.Extensions;
using Atelier.Cats.Application.Models;
using Atelier.Cats.Domain.Dtos;
using Atelier.Cats.Domain.Entities;
using Atelier.Cats.Domain.Repositories;
using Atelier.Cats.Domain.Services;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Cats.Application.Services
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

        public async Task<ChallengeDetailsDto> AddAsync(ChallengeCreationDto challenge)
        {
            // Check conflict
            var challengeExist = await _unitOfWork.ChallengeRepository
                .ExistsAsync(x => x.ChallengerOneId == challenge.ChallengerOneId
                    && x.ChallengerTwoId == challenge.ChallengerTwoId
                || x.ChallengerTwoId == challenge.ChallengerOneId
                    && x.ChallengerOneId == challenge.ChallengerTwoId);

            if (challengeExist)
            {
                throw new ConflictException("These cats have already faced each other");
            }

            // Check existence
            var contenderOneExists = await _unitOfWork.CatRepository.ExistsAsync(x => x.Id == challenge.ChallengerOneId);
            var contenderTwoExists = await _unitOfWork.CatRepository.ExistsAsync(x => x.Id == challenge.ChallengerTwoId);

            var sb = new StringBuilder();

            if (!contenderOneExists)
            {
                sb.Append($"The cat { challenge.ChallengerOneId } doesn't exist \r\n");
            }

            if (!contenderTwoExists)
            {
                sb.Append($"The cat { challenge.ChallengerTwoId } doesn't exist");
            }

            if (!contenderOneExists
                || !contenderTwoExists)
            {
                throw new BadRequestException(sb.ToString());
            }

            if (challenge.WinnerId != challenge.ChallengerOneId
                && challenge.WinnerId != challenge.ChallengerTwoId)
            {
                throw new BadRequestException("The challenge's winner must be one of the contenders");
            }

            var challengeToCreate = new Challenge
            {
                ChallengerOneId = challenge.ChallengerOneId,
                ChallengerTwoId = challenge.ChallengerTwoId,
                WinnerId = challenge.WinnerId,
                VoteDate = _dateGenerator.GetDate()
            };

            var createdChallenge = await _unitOfWork.ChallengeRepository.AddAsync(challengeToCreate);
            await _unitOfWork.CommitAsync();

            return createdChallenge.AsDto();
        }

        public Task<int> CountAsync()
        {
            return _unitOfWork.ChallengeRepository.CountAsync();
        }

        public async Task<ChallengeDetailsDto> FindAsync(Guid id)
        {
            var challenge = await _unitOfWork.ChallengeRepository.FindAsync(id);
            if (challenge is null)
            {
                throw new NotFoundException("The searched challenge wasn't found");
            }

            return challenge.AsDto();
        }
    }
}
