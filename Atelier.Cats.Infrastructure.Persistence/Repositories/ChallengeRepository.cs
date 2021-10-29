using Atelier.Cats.Domain.Entities;
using Atelier.Cats.Domain.Repositories;

namespace Atelier.Cats.Infrastructure.Persistence.Repositories
{
    public class ChallengeRepository : GenericRepository<Challenge>, IChallengeRepository
    {
        public ChallengeRepository(AtelierCatsContext context) : base(context)
        {
        }
    }
}
