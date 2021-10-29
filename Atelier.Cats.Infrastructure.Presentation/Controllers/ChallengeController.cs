using Atelier.Cats.Contracts;
using Atelier.Cats.Domain.Repositories;
using Atelier.Cats.Infrastructure.Presentation.Filters;
using Atelier.Cats.Services.Abstractions;
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

        public ChallengeController(
            ILogger<ChallengeController> logger,
            IUnitOfWork unitOfWork,
            IChallengeService challengeService) : base(logger, unitOfWork)
        {
            _challengeService = challengeService;
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
                var challenge = await UnitOfWork.ChallengeRepository.FindAsync(id);
                if (challenge != null)
                {
                    return Ok(challenge);
                }

                return NoContent();
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
                return Ok(await UnitOfWork.ChallengeRepository.CountAsync());
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
        /// <param name="challengeResult"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync(ChallengeResultDto challengeResult)
        {
            try
            {
                var challenge = await _challengeService.AddAsync(challengeResult);

                return Created("", challenge.Id);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.StackTrace, ex.Message);
                throw;
            }
        }
    }
}
