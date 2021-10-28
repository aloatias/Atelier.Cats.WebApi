using Atelier.Cats.DataAccess.Interfaces;
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
    public class CatController : AtelierControllerBase<CatController>
    {
        private readonly ICatService _catService; 

        public CatController(
            ILogger<CatController> logger,
            IUnitOfWork unitOfWork,
            ICatService catService) : base(logger, unitOfWork)
        {
            _catService = catService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpGet]
        [CatFilter]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            try
            {
                var cat = await UnitOfWork.CatRepository.FindAsync(id);
                if (cat != null)
                {
                    return Ok(cat);
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
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("atelier/{id}")]
        [HttpGet]
        [CatFilter]
        public async Task<IActionResult> GetByAtelierIdAsync(string id)
        {
            try
            {
                var cat = await UnitOfWork.CatRepository.FindByAtelierIdAsync(id);
                if (cat != null)
                {
                    return Ok(cat);
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
        [Route("Contenders")]
        [HttpGet]
        [ContendersFilter]
        public async Task<IActionResult> GetContendersAsync()
        {
            try
            {
                var contenders = await UnitOfWork.CatRepository.GetContendersAsync();
                if (contenders.Item1 != null
                    && contenders.Item2 != null)
                {
                    return Ok(contenders);
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
        [Route("Winners")]
        [HttpGet]
        [WinnersFilter]
        public async Task<IActionResult> GetWinnersAsync()
        {
            try
            {
                var winners = await UnitOfWork.CatRepository.GetWinnersAsync();
                if (winners != null)
                {
                    return Ok(winners);
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
        [Route("Catalog")]
        [HttpGet]
        public async Task<IActionResult> ImportCatalogAsync()
        {
            try
            {
                await _catService.ImportCatsCatalogAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.StackTrace, ex.Message);
                throw;
            }
        }
    }
}
