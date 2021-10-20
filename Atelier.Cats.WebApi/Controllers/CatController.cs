using Atelier.Cats.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Atelier.Cats.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatController : AtelierControllerBase
    {
        public CatController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [Route("Get")]
        [HttpGet]
        public async Task GetCatContendersAsync()
        {
            await UnitOfWork.CatRepository.GetContendersAsync();
        }
    }
}
