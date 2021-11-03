using Atelier.Cats.Application.Interfaces;
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

    public class NoContent<TEntity> : AtelierResponseBase<TEntity>, IAtelierResponse<TEntity>
    {
        public string ResourceUrl { get; set; }

        public NoContent(string errorMessage) : base(errorMessage)
        {
            SetStatusCode(HttpStatusCode.NoContent);
        }

        public NoContent(string errorMessage, TEntity content) : base(errorMessage, content)
        {
            SetStatusCode(HttpStatusCode.NoContent);
        }

    }
}
