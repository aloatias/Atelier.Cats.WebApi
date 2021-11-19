using Atelier.Cats.Application.Dtos;
using Atelier.Cats.Application.Interfaces;
using Atelier.Cats.Application.Models;
using Atelier.Cats.Domain.Entities;
using Atelier.Cats.Domain.Repositories;
using AutoMapper;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Cats.Application.Services
{
    public class ChallengeService : IChallengeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateProvider _dateProvider;
        private readonly IMapper _mapper;

        public ChallengeService(
            IUnitOfWork unitOfWork,
            IDateProvider dateProvider,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _dateProvider = dateProvider;
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(ChallengeCreationDto challenge)
        {
            // Check ids aren't equal
            if (challenge.WinnerId == challenge.LoserId)
            {
                throw new BadRequestException("The ids must be different");
            }

            // Check ids aren't empty
            if(challenge.WinnerId.Equals(Guid.Empty)
                || challenge.LoserId.Equals(Guid.Empty))
            {
                throw new BadRequestException("The ids cannont be empty");
            }

            // Check cats existence
            var contenderOneExists = await _unitOfWork.CatRepository.AnyAsync(x => x.Id == challenge.WinnerId);
            var contenderTwoExists = await _unitOfWork.CatRepository.AnyAsync(x => x.Id == challenge.LoserId);

            var sb = new StringBuilder();

            if (!contenderOneExists)
            {
                sb.Append($"The cat { challenge.WinnerId } doesn't exist \r\n");
            }

            if (!contenderTwoExists)
            {
                sb.Append($"The cat { challenge.LoserId } doesn't exist");
            }

            if (!contenderOneExists
                || !contenderTwoExists)
            {
                throw new BadRequestException(sb.ToString());
            }

            // Check challenge conflict
            var contenders = new Guid[] { challenge.WinnerId, challenge.LoserId };

            var existingChallenge = await _unitOfWork.ChallengeRepository
                .AnyAsync(x => contenders.Contains(x.WinnerId)
                    && contenders.Contains(x.LoserId));

            if (existingChallenge)
            {
                throw new ConflictException("These cats have already faced each other");
            }

            var challengeToCreate = _mapper.Map<Challenge>(challenge);
            challengeToCreate.VoteDate = _dateProvider.GetDate();

            var createdChallenge = await _unitOfWork.ChallengeRepository.AddAsync(challengeToCreate);
            await _unitOfWork.CommitAsync();

            return createdChallenge.Id;
        }

        public Task<int> CountAsync()
        {
            return _unitOfWork.ChallengeRepository.CountAsync();
        }

        public async Task<ChallengeDetailsDto> FindAsync(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                throw new BadRequestException("The searched id cannot be empty");
            }

            var challenge = await _unitOfWork.ChallengeRepository.FindAsync(id);
            if (challenge is null)
            {
                throw new NotFoundException("The searched challenge wasn't found");
            }

            return _mapper.Map<ChallengeDetailsDto>(challenge);
        }
    }
}
