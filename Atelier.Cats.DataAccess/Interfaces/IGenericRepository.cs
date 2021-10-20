﻿using Atelier.Cats.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Atelier.Cats.DataAccess.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>{
    public interface IGenericRepository<TEntity> where TEntity : AtelierEntityBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        Task AddAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// This method is used to check if an object exists according to a where expression
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> criteria);

        /// <summary>
        /// This method is used to save an object.
        /// </summary>
        /// <param name="entity">The object to save.</param>
        TEntity UpdateAsync(TEntity entity);

        /// <summary>
        /// This method is used to save a collection of objects.
        /// </summary>
        /// <param name="entities">The objects to save.</param>
        void UpdateAsync(IEnumerable<TEntity> entities, IDictionary<string, object> parameters = null);

        /// <summary>
        /// This method is used to delete an object based on its identifier.
        /// </summary>
        /// <param name="id">The identifier of the object to delete.</param>
        Task Remove(Guid id); // TODO: Add status code return

        /// <summary>
        /// This method is used to delete an object.
        /// </summary>
        /// <param name="entity">The object to delete</param>
        void Remove(TEntity entity); // TODO: Add status code return

        /// <summary>
        /// This method is used to delete multiple objects.
        /// </summary>
        /// <param name="entities">Objects to delete.</param>
        void Remove(IEnumerable<TEntity> entities);
    }
}