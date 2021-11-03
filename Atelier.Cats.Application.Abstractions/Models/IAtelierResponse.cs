using System.Net;

namespace Atelier.Cats.Application.Abstractions.Models
{
    public interface IAtelierResponse : IFailure
    {
        HttpStatusCode Status { get; }
    }

    public interface IAtelierResponse<TEntity> : IAtelierResponse, IContent<TEntity>
    {
        string ResourceUrl { get; set; }
    }
}
