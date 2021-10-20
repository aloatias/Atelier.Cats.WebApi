using Atelier.Cats.DataAccess.Entities;
using Atelier.Cats.DataAccess.Interfaces;
using System;
using System.Threading.Tasks;

namespace Atelier.Cats.DataAccess.Repositories
{
    public class CatRepository : GenericRepository<Cat>, ICatRepository
    {
        public CatRepository(AtelierCatsContext context) : base(context)
        {
        }

        public Task<Tuple<Cat, Cat>> GetContendersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
