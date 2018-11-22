using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using InfraData.DataContext;
using Microsoft.EntityFrameworkCore;

namespace InfraData.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity<T>
    {
        protected readonly DataBaseContext _dbContext;
        
        protected BaseRepository(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T GetById(int id)
        {
            return  _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);

            return entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public virtual void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).ToList();
        }

        public IEnumerable<T> All()
        {
            return _dbContext.Set<T>().ToList();
        }
    }
}