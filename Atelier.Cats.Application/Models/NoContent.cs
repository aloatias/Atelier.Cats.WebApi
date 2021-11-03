using Atelier.Cats.Application.Abstractions.Models;
using System.Net;

namespace Atelier.Cats.Application.Models
{
    public class NoContent : AtelierResponseBase, IAtelierResponse
    {
        public NoContent(string errorMessage) : base(errorMessage)
        {
            SetStatusCode(HttpStatusCode.NoContent);
        }
    }

    public class NoContent<TContent> : AtelierResponseBase<TContent>, IAtelierResponse<TContent>
    {
        public string ResourceUrl { get; set; }

        public NoContent(string errorMessage) : base(errorMessage)
        {
            SetStatusCode(HttpStatusCode.NoContent);
        }

        public NoContent(string errorMessage, TContent content) : base(errorMessage, content)
        {
            SetStatusCode(HttpStatusCode.NoContent);
        }

    }
}
