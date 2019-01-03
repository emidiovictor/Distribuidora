using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using InfraData.DataContext;
using Microsoft.EntityFrameworkCore;

namespace InfraData.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity<T>
    {
        protected readonly DataBaseContext _dbContext;
        protected readonly DbSet<T> entry;

        protected BaseRepository(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
            entry = dbContext.Set<T>();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);

        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public virtual void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> All()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
    }
}