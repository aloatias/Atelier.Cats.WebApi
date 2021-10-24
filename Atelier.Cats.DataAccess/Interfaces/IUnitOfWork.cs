using System.Threading.Tasks;

namespace Atelier.Cats.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        ICatRepository CatRepository { get; }
        IChallengeRepository ChallengeRepository { get; }
        Task CommitAsync();
    }
}
