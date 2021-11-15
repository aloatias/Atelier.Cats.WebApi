using Atelier.Cats.Domain.Entities;
using Atelier.Cats.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atelier.Cats.Infrastructure.Persistence.Repositories
{
    public class CatRepository : GenericRepository<Cat>, ICatRepository
    {
        private readonly AtelierCatsContext _context;

        public CatRepository(AtelierCatsContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Tuple<Cat, Cat>> GetContendersAsync()
        {
            Cat firstContender = null;
            Cat secondContender = null;

            if (await EntitySet.AnyAsync())
            {
                while (true)
                {
                    var contenders = await EntitySet?
                        .OrderBy(x => Guid.NewGuid())
                        .Take(2)
                        .ToArrayAsync();

                    var existingChallenge = await _context.Set<Challenge>()
                        .AnyAsync(x => contenders.Contains(x.Winner)
                            && contenders.Contains(x.Loser));

                    if (!existingChallenge)
                    {
                        firstContender = contenders[0];
                        secondContender = contenders[1];

                        break;
                    }
                }
            }

            return new Tuple<Cat, Cat>(firstContender, secondContender);
        }

        public async Task<IEnumerable<Cat>> GetWinnersAsync()
        {
            return await EntitySet
                .Include(x => x.ChallengesWinner)
                .Where(x => x.ChallengesWinner.Any())
                .OrderByDescending(x => x.ChallengesWinner.Count())
                .ToListAsync();
        }
    }
}