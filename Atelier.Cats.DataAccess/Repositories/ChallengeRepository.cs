using Atelier.Cats.DataAccess.Entities;
using Atelier.Cats.DataAccess.Interfaces;
using System;
using System.Collections.Generic;

namespace Atelier.Cats.DataAccess.Repositories
{
    public class ChallengeRepository : GenericRepository<Challenge>, IChallengeRepository
    {
        public ChallengeRepository(AtelierCatsContext context) : base(context)
        {
        }

        public IReadOnlyCollection<Challenge> GetResultsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
