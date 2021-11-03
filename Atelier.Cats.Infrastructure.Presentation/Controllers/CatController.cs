using Atelier.Cats.Application.Abstractions.Services;
using Atelier.Cats.Infrastructure.Presentation.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Atelier.Cats.Infrastructure.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatController : AtelierControllerBase<CatController>
    {
        private readonly ICatService _catService;

        public CatController(
            ILogger<CatController> logger,
            ICatService catService) : base(logger)
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
                return SendResponse(await _catService.FindAsync(id));
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
                return SendResponse(await _catService.FindAsync(id));
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
                return SendResponse(await _catService.GetContendersAsync());
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
                return SendResponse(await _catService.GetWinnersAsync());
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
                return SendResponse(await _catService.ImportCatsCatalogAsync());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.StackTrace, ex.Message);
                throw;
            }
        }
    }
}
