using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Equinox.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        EntityEntry<T> Insert(T entity);

        void InsertMany(IEnumerable<T> entities);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);

        T GetById(Guid id);

        T GetByManyId(IEnumerable<Guid> ids);

        IQueryable<T> GetAll();

        IQueryable<T> GetAllAsNoTracking();

        IQueryable<T> GetMany(System.Linq.Expressions.Expression<Func<T, bool>> predicate);

        IQueryable<T> GetManyAsNoTracking(System.Linq.Expressions.Expression<Func<T, bool>> predicate);

        EntityEntry<T> Update(T entity);

        void UpdateRange(IEnumerable<T> entities);
    }
}
