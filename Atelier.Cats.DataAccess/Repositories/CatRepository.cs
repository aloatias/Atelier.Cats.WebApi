using Atelier.Cats.DataAccess.Entities;
using Atelier.Cats.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atelier.Cats.DataAccess.Repositories
{
    public class CatRepository : GenericRepository<Cat>, ICatRepository
    {
        private readonly AtelierCatsContext _context;

        public CatRepository(AtelierCatsContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Cat> FindByAtelierIdAsync(string id)
        {
            return await EntitySet.FirstOrDefaultAsync(x => x.AtelierId == id);
        }

        public async Task<Tuple<Cat, Cat>> GetContendersAsync()
        {
            Cat firstContender = null;
            Cat secondContender = null;

            while (true && await EntitySet.AnyAsync())
            {
                firstContender = await EntitySet
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefaultAsync();

                secondContender = await EntitySet
                    .Where(x => x.Id != firstContender.Id)
                    .OrderBy(x => Guid.NewGuid())
                    .FirstOrDefaultAsync();

                bool existingChallenge = await _context
                    .Set<Challenge>()
                    .AnyAsync(x =>
                    (x.ChallengerOneId == firstContender.Id 
                        && x.ChallengerTwoId == secondContender.Id)
                    || (x.ChallengerTwoId == firstContender.Id
                        && x.ChallengerOneId == firstContender.Id));

                if (!existingChallenge)
                {
                    break;
                }
            }

            return new Tuple<Cat, Cat>(firstContender, secondContender);
        }

        public async Task<IReadOnlyCollection<Cat>> GetWinnersAsync()
        {
            return await EntitySet
                .Include(x => x.ChallengesWinner)
                .Where(x => x.ChallengesWinner.Any())
                .OrderByDescending(x => x.ChallengesWinner.ToList().Count)
                .ToListAsync();
        }
    }
}
