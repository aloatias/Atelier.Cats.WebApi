using Atelier.Cats.Application.Abstractions.Models;
using System.Net;

namespace Atelier.Cats.Application.Models
{
    public class BadRequest : AtelierResponseBase, IAtelierResponse
    {
        public BadRequest(string errorMessage) : base(errorMessage)
        {
            SetStatusCode(HttpStatusCode.BadRequest);
        }
    }

    public class BadRequest<TContent> : AtelierResponseBase<TContent>, IAtelierResponse<TContent>
    {
        public string ResourceUrl { get; set; }

        public BadRequest(string errorMessage) : base(errorMessage)
        {
            SetStatusCode(HttpStatusCode.BadRequest);
        }

        public BadRequest(string errorMessage, TContent content) : base(errorMessage, content)
        {
            SetStatusCode(HttpStatusCode.BadRequest);
        }
    }
}
