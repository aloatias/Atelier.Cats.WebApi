using Atelier.Cats.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atelier.Cats.WebApi.Controllers
{
    public class AtelierControllerBase : ControllerBase
    {
        protected IUnitOfWork UnitOfWork { get; private set; }

        public AtelierControllerBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}