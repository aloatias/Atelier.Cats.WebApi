using Atelier.Cats.DataAccess.Entities;
using Atelier.Cats.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<Tuple<Cat, Cat>> GetContendersAsync()
        {
            Cat firstContender;
            Cat secondContender;

            while (true)
            {
                firstContender = await EntitySet
                .OrderBy(x => new Guid())
                .FirstOrDefaultAsync();

                secondContender = await EntitySet
                    .Where(x => x.Id != firstContender.Id)
                    .OrderBy(x => new Guid())
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
    }
}
