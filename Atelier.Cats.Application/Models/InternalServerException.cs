using System;

namespace Atelier.Cats.Application.Models
{
    public class InternalServerException : Exception
    {
        public InternalServerException(string errorMessage) : base(errorMessage)
        {
        }

        public InternalServerException(string errorMessage, Exception exception) : base(errorMessage, exception)
        {
        }
    }
}
