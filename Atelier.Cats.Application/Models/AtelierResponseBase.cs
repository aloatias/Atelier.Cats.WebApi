using System;
using System.Net;

namespace Atelier.Cats.Application.Models
{
    public abstract class AtelierResponseBase
    {
        public HttpStatusCode Status { get; private set; }
        public string ErrorMessage { get; private set; }
        public Exception Exception { get; private set; }

        protected AtelierResponseBase()
        {
        }

        protected AtelierResponseBase(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        protected AtelierResponseBase(string errorMessage, Exception exception)
        {
            ErrorMessage = errorMessage;
            Exception = exception;
        }

        protected void SetStatusCode(HttpStatusCode status)
        {
            Status = status;
        }
    }

    public abstract class AtelierResponseBase<TEntity>
    {
        public HttpStatusCode Status { get; private set; }
        public TEntity Content { get; private set; }
        public string ErrorMessage { get; private set; }
        public Exception Exception { get; private set; }

        protected AtelierResponseBase(TEntity content)
        {
            Content = content;
        }

        protected AtelierResponseBase(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        protected AtelierResponseBase(string errorMessage, TEntity defaultContent)
        {
            ErrorMessage = errorMessage;
            Content = defaultContent;
        }

        protected AtelierResponseBase(string errorMessage, Exception exception)
        {
            ErrorMessage = errorMessage;
            Exception = exception;
        }

        protected AtelierResponseBase(string errorMessage, TEntity content, Exception exception)
        {
            ErrorMessage = errorMessage;
            Content = content;
            Exception = exception;
        }

        protected void SetStatusCode(HttpStatusCode status)
        {
            Status = status;
        }
    }
}
