using Atelier.Cats.DataAccess.Interfaces;
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

        [Route("ImportCatsCatalog")]
        [HttpGet]
        public async Task<IActionResult> ImportCatsCatalogAsync()
        {
            try
            {
                await _catService.ImportCatsCatalogAsync();
                return Ok();
            }
            catch (Exception ex)
            {
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
                throw;
            }
        }
    }
}
