using Atelier.Cats.DataAccess.Interfaces;
using Atelier.Cats.WebApi.Dtos;
using Atelier.Cats.WebApi.Filters;
using Atelier.Cats.WebApi.Interfaces;
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
        private readonly IChallengeService _challengeService;

        public ChallengeControler(
            ILogger<ChallengeControler> logger,
            IUnitOfWork unitOfWork,
            IChallengeService challengeService) : base(logger, unitOfWork)
        {
            _challengeService = challengeService;
        }

        [Route("Get/{id}")]
        [HttpGet]
        [GetChallengeFilter]
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

        [Route("Add")]
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
