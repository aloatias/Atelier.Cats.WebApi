using System.Net;

namespace Atelier.Cats.Application.Interfaces
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
