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
    [Route("api/[controller]")]
    public class ChallengesController : AtelierControllerBase<ChallengesController>
    {
        private readonly IChallengeService _challengeService;

        public ChallengesController(
            ILogger<ChallengesController> logger,
            IChallengeService challengeService) : base(logger)
        {
            _challengeService = challengeService;
        }

        // POST /challenge
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddAsync(ChallengeCreationDto challengeResult)
        {
            var createdChallengeId = await _challengeService.AddAsync(challengeResult);

            return Created(nameof(GetAsync), new { id = createdChallengeId });
        }

        // GET /challenge/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            return Ok(await _challengeService.FindAsync(id));
        }

        // GET /challenge/total-votes
        [HttpGet("total-votes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTotalVotesAsync()
        {
            return Ok(await _challengeService.CountAsync());
        }
    }
}
