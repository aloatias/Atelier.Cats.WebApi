using Atelier.Cats.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Atelier.Cats.WebApi.Controllers
{
    public class AtelierControllerBase : ControllerBase
    {
        protected ILogger Logger { get; private set; }
        protected IUnitOfWork UnitOfWork { get; private set; }

        public AtelierControllerBase(
            ILogger logger,
            IUnitOfWork unitOfWork)
        {
            Logger = logger;
            UnitOfWork = unitOfWork;
        }
    }
}