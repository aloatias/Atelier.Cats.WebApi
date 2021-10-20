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
        private readonly DbSet<TEntity> _entitySet;

        public GenericRepository(AtelierCatsContext atelierCatsContext)
        {
            _entitySet = atelierCatsContext.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return (await _entitySet.AddAsync(entity)).Entity;
        }

        public async Task AddAsync(IEnumerable<TEntity> entities)
        {
            await _entitySet.AddRangeAsync(entities);
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> criteria)
        {
            return await _entitySet.AnyAsync(criteria);
        }

        public async Task Remove(Guid id)
        {
            var entity = await _entitySet.FindAsync(id);
            _entitySet.Remove(entity);
        }

        public void Remove(TEntity entity)
        {
            _entitySet.Remove(entity);
        }

        public void Remove(IEnumerable<TEntity> entities)
        {
            _entitySet.RemoveRange(entities);
        }

        public TEntity UpdateAsync(TEntity entity)
        {
            return (_entitySet.Update(entity)).Entity;
        }

        public void UpdateAsync(IEnumerable<TEntity> entities, IDictionary<string, object> parameters = null)
        {
            throw new NotImplementedException();
        }
    }
}
