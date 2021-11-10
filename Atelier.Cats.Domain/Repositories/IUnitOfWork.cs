using System.Threading.Tasks;

namespace Atelier.Cats.Domain.Repositories
{
    public interface IUnitOfWork
    {
        ICatRepository CatRepository { get; }
        IChallengeRepository ChallengeRepository { get; }
        Task CommitAsync();
    }
}
