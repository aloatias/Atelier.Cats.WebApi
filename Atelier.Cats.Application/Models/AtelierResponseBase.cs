using System;
using System.Net;

namespace Atelier.Cats.Application.Models
{
    public abstract class AtelierResponseBase
    {
        public HttpStatusCode Status { get; private set; }
        public string ErrorMessage { get; private set; }

        protected AtelierResponseBase()
        {
        }

        protected AtelierResponseBase(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        protected void SetStatusCode(HttpStatusCode status)
        {
            Status = status;
        }
    }

    public abstract class AtelierResponseBase<TContent>
    {
        public HttpStatusCode Status { get; private set; }
        public TContent Content { get; private set; }
        public string ErrorMessage { get; private set; }
        public Exception Exception { get; private set; }

        protected AtelierResponseBase(TContent content)
        {
            Content = content;
        }

        protected AtelierResponseBase(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        protected AtelierResponseBase(string errorMessage, TContent content)
        {
            ErrorMessage = errorMessage;
            Content = content;
        }

        protected void SetStatusCode(HttpStatusCode status)
        {
            Status = status;
        }
    }
}
