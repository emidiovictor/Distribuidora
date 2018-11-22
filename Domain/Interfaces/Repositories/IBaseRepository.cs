using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity<T>
    {
        T GetById(int id);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> All();
    }
}