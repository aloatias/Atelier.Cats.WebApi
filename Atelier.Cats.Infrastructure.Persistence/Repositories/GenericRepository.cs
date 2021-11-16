using Atelier.Cats.Domain.Entities;
using Atelier.Cats.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Atelier.Cats.Infrastructure.Persistence.Repositories
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

        public Task AddAsync(IEnumerable<TEntity> entities)
        {
            return EntitySet.AddRangeAsync(entities);
        }

        public Task<int> CountAsync()
        {
            return EntitySet.CountAsync();
        }

        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> criteria)
        {
            return EntitySet.AnyAsync(criteria);
        }

        public async Task<TEntity> FindAsync(Guid id)
        {
            return await EntitySet.FindAsync(id);
        }

        public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return EntitySet.FirstOrDefaultAsync(predicate);
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
            return EntitySet.Update(entity).Entity;
        }
    }
}
