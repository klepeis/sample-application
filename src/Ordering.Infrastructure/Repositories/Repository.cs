using Microsoft.EntityFrameworkCore;
using Ordering.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ordering.Infrastructure.Repositories
{
    /// <summary>
    /// This is the base class for any Entity Framework Repository Object.  This object contains generic implementations for the shared base functionality.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #region Methods used to locate an Entity/Entities

        /// <summary>
        /// Retrieve entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Retrieve all Entities.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Retrieve entities using a lambda expression.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        /// <summary>
        /// Retrieve a single entity using a lambda expression.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        #endregion

        #region Metthods used to add an Entity/Entities

        /// <summary>
        /// Method to add an item of TEntity to the DbContext in memory.
        /// Persistance is managed through unit of work.
        /// </summary>
        /// <param name="entity"></param>
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }


        /// <summary>
        /// Method to add multiple items of TEntity to the DbContext in memory.
        /// Persistance is managed through unit of work.
        /// </summary>
        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        #endregion

        #region Methods used to remove an Entity/Entities

        /// <summary>
        /// Method to remove an item of TEntity to the DbContext in memory.
        /// Persistance is managed through unit of work.
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Method to remove items of TEntity to the DbContext in memory.
        /// Persistance is managed through unit of work.
        /// </summary>
        /// <param name="entity"></param>
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        #endregion
    }
}
