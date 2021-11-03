using Atelier.Cats.Application.Abstractions.Services;
using Atelier.Cats.Contracts;
using Atelier.Cats.Domain.Entities;
using Atelier.Cats.Infrastructure.Presentation.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Atelier.Cats.Infrastructure.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChallengeController : AtelierControllerBase<ChallengeController>
    {
        private readonly IChallengeService _challengeService;
        private readonly IDateGeneratorService _dateGeneratorService;

        public ChallengeController(
            ILogger<ChallengeController> logger,
            IChallengeService challengeService,
            IDateGeneratorService dateGeneratorService) : base(logger)
        {
            _challengeService = challengeService;
            _dateGeneratorService = dateGeneratorService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="challengeResult"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync(ChallengeResultDto challengeResult)
        {
            try
            {
                var challengeToAdd = new Challenge
                {
                    ChallengerOneId = challengeResult.ChallengerOneId,
                    ChallengerTwoId = challengeResult.ChallengerTwoId,
                    WinnerId = challengeResult.WinnerId,
                    VoteDate = _dateGeneratorService.GetDate()
                };

                return SendResponse(await _challengeService.AddAsync(challengeToAdd));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.StackTrace, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpGet]
        [ChallengeFilter]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            try
            {
                return SendResponse(await _challengeService.FindAsync(id));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.StackTrace, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("TotalVotes")]
        [HttpGet]
        public async Task<IActionResult> GetTotalVotesAsync()
        {
            try
            {
                return SendResponse(await _challengeService.CountAsync());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.StackTrace, ex.Message);
                throw;
            }
        }
    }
}
