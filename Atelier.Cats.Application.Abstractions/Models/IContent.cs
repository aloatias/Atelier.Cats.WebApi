namespace Atelier.Cats.Application.Abstractions.Models
{
    public interface IContent<TContent>
    {
        TContent Content { get; }
    }
}
