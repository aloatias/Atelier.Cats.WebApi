using Atelier.Cats.Application.Dtos;
using Atelier.Cats.Application.Interfaces;
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

        public ChallengeController(
            ILogger<ChallengeController> logger,
            IChallengeService challengeService) : base(logger)
        {
            _challengeService = challengeService;
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
        [Route("total-votes")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTotalVotesAsync()
        {
            return Ok(await _challengeService.CountAsync());
        }
    }
}
