using Atelier.Cats.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Atelier.Cats.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AtelierCatsContext _context;

        public ICatRepository CatRepository { get; private set; }
        public IChallengeRepository ChallengeRepository { get; private set; }

        public UnitOfWork(
            AtelierCatsContext context,
            ICatRepository catRepository,
            IChallengeRepository challengeRepository)
        {
            _context = context;
            CatRepository = catRepository;
            ChallengeRepository = challengeRepository;
        }

        public async Task CommitAsync()
        {
            using var dbContextTransaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.SaveChangesAsync();
                await dbContextTransaction.CommitAsync();
            }
            catch
            {
                //Log Exception Handling message                      
                await dbContextTransaction.RollbackAsync();
                throw;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
