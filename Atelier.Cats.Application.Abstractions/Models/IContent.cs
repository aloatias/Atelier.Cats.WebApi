namespace Atelier.Cats.Application.Abstractions.Models
{
    public interface IContent<TEntity>
    {
        TEntity Content { get; }
    }
}
