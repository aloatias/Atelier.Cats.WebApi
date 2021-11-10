using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Atelier.Cats.Infrastructure.Presentation.Controllers
{
    public class AtelierControllerBase<TController> : ControllerBase
    {
        protected ILogger<TController> Logger { get; private set; }

        public AtelierControllerBase(
            ILogger<TController> logger)
        {
            Logger = logger;
        }
    }
}