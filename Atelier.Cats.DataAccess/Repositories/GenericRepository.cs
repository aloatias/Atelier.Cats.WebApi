using Atelier.Cats.DataAccess.Entities;
using Atelier.Cats.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Atelier.Cats.DataAccess.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : AtelierEntityBase
    {
        protected DbSet<TEntity> EntitySet { get; private set; }

        public GenericRepository(AtelierCatsContext atelierCatsContext)
        {
            EntitySet = atelierCatsContext.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return (await EntitySet.AddAsync(entity)).Entity;
        }

        public async Task AddAsync(IEnumerable<TEntity> entities)
        {
            await EntitySet.AddRangeAsync(entities);
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> criteria)
        {
            return await EntitySet.AnyAsync(criteria);
        }

        public async Task<TEntity> FindAsync(Guid id)
        {
            return await EntitySet.FindAsync(id);
        }

        public async Task Remove(Guid id)
        {
            var entity = await EntitySet.FindAsync(id);
            EntitySet.Remove(entity);
        }

        public void Remove(TEntity entity)
        {
            EntitySet.Remove(entity);
        }

        public void Remove(IEnumerable<TEntity> entities)
        {
            EntitySet.RemoveRange(entities);
        }

        public TEntity UpdateAsync(TEntity entity)
        {
            return (EntitySet.Update(entity)).Entity;
        }

        public void UpdateAsync(IEnumerable<TEntity> entities, IDictionary<string, object> parameters = null)
        {
            throw new NotImplementedException();
        }
    }
}
