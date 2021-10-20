using Atelier.Cats.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Atelier.Cats.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatController : AtelierControllerBase
    {
        public CatController(
            ILogger logger,
            IUnitOfWork unitOfWork) : base(logger, unitOfWork)
        {
        }

        [Route("GetContenders")]
        [HttpGet]
        public async Task GetCatContendersAsync()
        {
            await UnitOfWork.CatRepository.GetContendersAsync();
        }
    }
}
