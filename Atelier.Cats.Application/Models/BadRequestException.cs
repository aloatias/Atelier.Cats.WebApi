using System.Net;

namespace Atelier.Cats.Application.Models
{
    public sealed class BadRequestException : AtelierExceptionBase
    {
        public BadRequestException(string errorMessage) : base(errorMessage)
        {
            SetStatusCode(HttpStatusCode.BadRequest);
        }
    }
}
