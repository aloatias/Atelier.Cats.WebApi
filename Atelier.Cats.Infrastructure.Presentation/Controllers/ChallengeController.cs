using Atelier.Cats.Application.Abstractions.Services;
using Atelier.Cats.Contracts;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddAsync(ChallengeCreationDto challengeResult)
        {
            var createdChallenge = await _challengeService.AddAsync(challengeResult);

            return Created("", new { id = createdChallenge.Id });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTotalVotesAsync()
        {
            return Ok(await _challengeService.CountAsync());
        }
    }
}
