using System;
using System.Net;

namespace Atelier.Cats.Application.Models
{
    public abstract class AtelierExceptionBase : Exception
    {
        public HttpStatusCode HttpStatusCode { get; private set; }

        protected AtelierExceptionBase(string errorMessage) : base(errorMessage)
        {
        }

        protected void SetStatusCode(HttpStatusCode httpStatusCode)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
