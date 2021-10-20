using Atelier.Cats.DataAccess.Entities;
using Atelier.Cats.DataAccess.Interfaces;
using System;
using System.Threading.Tasks;

namespace Atelier.Cats.DataAccess.Repositories
{
    public class ChallengeRepository : GenericRepository<Challenge>, IChallengeRepository
    {
        public ChallengeRepository(AtelierCatsContext context) : base(context)
        {
        }

        public async Task GetResultsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
