using Atelier.Cats.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Atelier.Cats.Infrastructure.Presentation.Controllers
{
    public class AtelierControllerBase<TEntity> : ControllerBase
    {
        protected ILogger<TEntity> Logger { get; private set; }
        protected IUnitOfWork UnitOfWork { get; private set; }

        public AtelierControllerBase(
            ILogger<TEntity> logger,
            IUnitOfWork unitOfWork)
        {
            Logger = logger;
            UnitOfWork = unitOfWork;
        }
    }
}