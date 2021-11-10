using Atelier.Cats.Application.Abstractions.Services;
using Atelier.Cats.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CatDetailsDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            return Ok(await _catService.FindAsync(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("atelier/{id}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CatDetailsDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByAtelierIdAsync(string id)
        {
            return Ok(await _catService.FindAsync(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("Contenders")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContendersCoupleDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetContendersAsync()
        {
            return Ok(await _catService.GetContendersAsync());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("Winners")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CatDetailsDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWinnersAsync()
        {
            return Ok(await _catService.GetWinnersAsync());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("Catalog")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ImportCatalogAsync()
        {
            await _catService.ImportCatsCatalogAsync();
            return NoContent();
        }
    }
}
