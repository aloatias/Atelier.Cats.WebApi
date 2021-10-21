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

        [Route("Get/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            try
            {
                return Ok(await UnitOfWork.CatRepository.FindAsync(id));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.StackTrace, ex.Message);
                throw;
            }
        }

        [Route("GetByAtelierId/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetByAtelierIdAsync(string id)
        {
            try
            {
                return Ok(await UnitOfWork.CatRepository.FindByAtelierIdAsync(id));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.StackTrace, ex.Message);
                throw;
            }
        }

        [Route("GetContenders")]
        [HttpGet]
        public async Task<IActionResult> GetContendersAsync()
        {
            try
            {
                return Ok(await UnitOfWork.CatRepository.GetContendersAsync());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.StackTrace, ex.Message);
                throw;
            }
        }

        [Route("GetWinners")]
        [HttpGet]
        [GetWinnersFilter]
        public async Task<IActionResult> GetWinnersAsync()
        {
            try
            {
                return Ok(await UnitOfWork.CatRepository.GetWinnersAsync());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.StackTrace, ex.Message);
                throw;
            }
        }

        [Route("ImportCatsCatalog")]
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
