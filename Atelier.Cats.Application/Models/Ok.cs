using Atelier.Cats.Application.Abstractions.Models;
using System.Net;

namespace Atelier.Cats.Application.Models
{
    public class Ok : AtelierResponseBase, IAtelierResponse
    {
        public Ok()
        {
            SetStatusCode(HttpStatusCode.OK);
        }
    }

    public class Ok<TContent> : AtelierResponseBase<TContent>, IAtelierResponse<TContent>
    {
        public string ResourceUrl { get; set; }

        public Ok(TContent content) : base(content)
        {
            SetStatusCode(HttpStatusCode.OK);
        }
    }
}
