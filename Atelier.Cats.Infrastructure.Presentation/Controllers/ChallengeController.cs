using Atelier.Cats.Application.Interfaces;
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

        public ChallengeController(
            ILogger<ChallengeController> logger,
            IChallengeService challengeService) : base(logger)
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
                return Ok((await _challengeService.CountAsync()).Content);
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
                return SendResponse(await _challengeService.AddAsync(challengeResult));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.StackTrace, ex.Message);
                throw;
            }
        }
    }
}
