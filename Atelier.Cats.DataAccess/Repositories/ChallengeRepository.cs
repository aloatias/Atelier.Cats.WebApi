using Atelier.Cats.DataAccess.Entities;
using Atelier.Cats.DataAccess.Interfaces;

namespace Atelier.Cats.DataAccess.Repositories
{
    public class ChallengeRepository : GenericRepository<Challenge>, IChallengeRepository
    {
        public ChallengeRepository(AtelierCatsContext context) : base(context)
        {
        }
    }
}
