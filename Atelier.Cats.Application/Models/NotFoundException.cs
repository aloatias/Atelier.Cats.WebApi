using System.Net;

namespace Atelier.Cats.Application.Models
{
    public sealed class NotFoundException : AtelierExceptionBase
    {
        public NotFoundException(string errorMessage) : base(errorMessage)
        {
            SetStatusCode(HttpStatusCode.NoContent);
        }
    }
}
