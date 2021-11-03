using Atelier.Cats.Application.Interfaces;
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

    public class Created<TEntity> : AtelierResponseBase<TEntity>, IAtelierResponse<TEntity>
    {
        public string ResourceUrl { get; set; }
        
        public Created(TEntity content) : base(content)
        {
            SetStatusCode(HttpStatusCode.OK);
        }
    }
}