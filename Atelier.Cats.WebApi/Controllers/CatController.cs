using Atelier.Cats.DataAccess.Interfaces;
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
        public CatController(
            ILogger<CatController> logger,
            IUnitOfWork unitOfWork) : base(logger, unitOfWork)
        {
        }

        [Route("GetContenders")]
        [HttpGet]
        public async Task GetContendersAsync()
        {
            try
            {
                await UnitOfWork.CatRepository.GetContendersAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
