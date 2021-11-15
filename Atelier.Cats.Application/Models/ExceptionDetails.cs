using System.Text.Json;

namespace Atelier.Cats.Application.Models
{
    public sealed class ExceptionDetails
    {
        public int StatusCode { get; private set; }
        public string Message { get; private set; }

        public ExceptionDetails(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
