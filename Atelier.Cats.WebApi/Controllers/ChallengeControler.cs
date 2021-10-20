using Atelier.Cats.DataAccess.Entities;
using Atelier.Cats.DataAccess.Interfaces;
using Atelier.Cats.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Atelier.Cats.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChallengeControler : AtelierControllerBase<ChallengeControler>
    {
        private readonly IDateGenerator _dateGenerator;

        public ChallengeControler(
            ILogger<ChallengeControler> logger,
            IUnitOfWork unitOfWork,
            IDateGenerator dateGenerator) : base(logger, unitOfWork)
        {
            _dateGenerator = dateGenerator;
        }

        [HttpPost]
        public async Task SetChallengeResultAsync(ChallengeResultDto challengeResult)
        {
            try
            {
                var challenge = new Challenge
                {
                    ChallengerOneId = challengeResult.ChallengerOneId,
                    ChallengerTwoId = challengeResult.ChallengerTwoId,
                    WinnerId = challengeResult.WinnerId,
                    VoteDate = _dateGenerator.GetDate()
                };

                await UnitOfWork.ChallengeRepository.AddAsync(challenge);
                await UnitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
