using System;
using System.Collections.Generic;
using System.Linq;
using Equinox.Domain.Interfaces;
using Equinox.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Equinox.Infra.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Insert        
        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public EntityEntry<T> Insert(T entity)
        {
            return _unitOfWork.Context.Set<T>().Add(entity);
        }

        /// <summary>
        /// Insert many entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void InsertMany(IEnumerable<T> entities)
        {
            _unitOfWork.Context.Set<T>().AddRange(entities);
        }
        #endregion

        #region Delete        
        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(T entity)
        {
            T existing = _unitOfWork.Context.Set<T>().Find(entity);
            if (existing != null) _unitOfWork.Context.Set<T>().Remove(existing);
        }

        /// <summary>
        /// Deletes the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void DeleteRange(IEnumerable<T> entities)
        {
            IEnumerable<T> existing = new List<T>();

            foreach (var item in entities)
            {
                T A = _unitOfWork.Context.Set<T>().Find(item);
                existing.ToList().Add(A);
            }
            if (existing != null) _unitOfWork.Context.Set<T>().RemoveRange(existing);
        }

        #endregion

        #region Get        
        /// <summary>
        /// Gets by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public T GetById(Guid id)
        {
            return _unitOfWork.Context.Set<T>().Find(id);
        }

        /// <summary>
        /// Gets the by many identifier.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
        public T GetByManyId(IEnumerable<Guid> ids)
        {
            return _unitOfWork.Context.Set<T>().Find(ids);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return _unitOfWork.Context.Set<T>().AsQueryable<T>();
        }

        /// <summary>
        /// Gets all as no tracking.
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAllAsNoTracking()
        {
            return _unitOfWork.Context.Set<T>().AsQueryable<T>().AsNoTracking();
        }

        /// <summary>
        /// Gets many.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public IQueryable<T> GetMany(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _unitOfWork.Context.Set<T>().Where(predicate).AsQueryable<T>();
        }

        /// <summary>
        /// Gets many as no tracking.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public IQueryable<T> GetManyAsNoTracking(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _unitOfWork.Context.Set<T>().Where(predicate).AsQueryable<T>();
        }
        #endregion

        #region Update        
        /// <summary>
        /// Updates specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public EntityEntry<T> Update(T entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            return _unitOfWork.Context.Set<T>().Attach(entity);
        }

        /// <summary>
        /// Updates the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void UpdateRange(IEnumerable<T> entities)
        {
            foreach (var item in entities)
            {
                _unitOfWork.Context.Entry(item).State = EntityState.Modified;
            }
            _unitOfWork.Context.Set<T>().AttachRange(entities);
        }
        #endregion
    }
}
