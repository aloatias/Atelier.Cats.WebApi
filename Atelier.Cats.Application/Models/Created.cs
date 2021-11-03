using Atelier.Cats.Application.Abstractions.Models;
using System.Net;

namespace Atelier.Cats.Application.Models
{
    public class Created : AtelierResponseBase, IAtelierResponse
    {
        public Created()
        {
            SetStatusCode(HttpStatusCode.Created);
        }
    }

    public class Created<TContent> : AtelierResponseBase<TContent>, IAtelierResponse<TContent>
    {
        public string ResourceUrl { get; set; }
        
        public Created(TContent content) : base(content)
        {
            SetStatusCode(HttpStatusCode.OK);
        }
    }
}