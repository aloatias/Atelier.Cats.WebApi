using Atelier.Cats.Application.Interfaces;
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

    public class Ok<TEntity> : AtelierResponseBase<TEntity>, IAtelierResponse<TEntity>
    {
        public string ResourceUrl { get; set; }

        public Ok(TEntity content) : base(content)
        {
            SetStatusCode(HttpStatusCode.OK);
        }
    }
}
