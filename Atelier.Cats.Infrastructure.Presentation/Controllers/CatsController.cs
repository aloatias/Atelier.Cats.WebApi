using Atelier.Cats.Application.Dtos;
using Atelier.Cats.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atelier.Cats.Infrastructure.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatsController : AtelierControllerBase<CatsController>
    {
        private readonly ICatService _catService;

        public CatsController(
            ILogger<CatsController> logger,
            ICatService catService) : base(logger)
        {
            _catService = catService;
        }

        // GET /cats/{id}
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CatDetailsDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            return Ok(await _catService.FindAsync(id));
        }

        // GET /cats/{atelierId}
        [HttpGet("{atelierId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CatDetailsDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByAtelierIdAsync(string atelierId)
        {
            return Ok(await _catService.FindAsync(atelierId));
        }

        // GET /cats/contenders
        [HttpGet("contenders")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContendersCoupleDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetContendersAsync()
        {
            return Ok(await _catService.GetContendersAsync());
        }

        // GET /cats/winners
        [HttpGet("winners")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CatDetailsDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWinnersAsync()
        {
            return Ok(await _catService.GetWinnersAsync());
        }

        // GET /cats/catalog
        [HttpGet("catalog")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ImportCatalogAsync()
        {
            await _catService.ImportCatsCatalogAsync();
            return NoContent();
        }
    }
}
