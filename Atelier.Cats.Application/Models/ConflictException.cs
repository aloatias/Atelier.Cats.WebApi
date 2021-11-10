using System.Net;

namespace Atelier.Cats.Application.Models
{
    public sealed class ConflictException : AtelierExceptionBase
    {
        public ConflictException(string errorMessage) : base(errorMessage)
        {
            SetStatusCode(HttpStatusCode.Conflict);
        }
    }
}
