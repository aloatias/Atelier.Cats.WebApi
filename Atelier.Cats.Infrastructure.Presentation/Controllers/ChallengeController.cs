using Atelier.Cats.Application.Abstractions.Services;
using Atelier.Cats.Contracts;
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
        private readonly IDateGenerator _dateGeneratorService;

        public ChallengeController(
            ILogger<ChallengeController> logger,
            IChallengeService challengeService,
            IDateGenerator dateGeneratorService) : base(logger)
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
        public async Task<IActionResult> AddAsync(ChallengeCreationDto challengeResult)
        {
            var createdChallenge = await _challengeService.AddAsync(challengeResult);

            return CreatedAtRoute("", new { id = createdChallenge.Id });
            //return Created("", createdChallenge.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            return Ok(await _challengeService.FindAsync(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("TotalVotes")]
        [HttpGet]
        public async Task<IActionResult> GetTotalVotesAsync()
        {
            return Ok(await _challengeService.CountAsync());
        }
    }
}
