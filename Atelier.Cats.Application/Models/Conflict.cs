using Atelier.Cats.Application.Abstractions.Models;
using System.Net;

namespace Atelier.Cats.Application.Models
{
    public class Conflict : AtelierResponseBase, IAtelierResponse
    {
        public Conflict(string errorMessage) : base(errorMessage)
        {
            SetStatusCode(HttpStatusCode.Conflict);
        }
    }

    public class Conflict<TContent> : AtelierResponseBase<TContent>, IAtelierResponse<TContent>
    {
        public string ResourceUrl { get; set; }

        public Conflict(string errorMessage) : base(errorMessage)
        {
            SetStatusCode(HttpStatusCode.Conflict);
        }

        public Conflict(string errorMessage, TContent content) : base(errorMessage, content)
        {
            SetStatusCode(HttpStatusCode.Conflict);
        }
    }
}
