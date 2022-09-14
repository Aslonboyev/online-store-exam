using Microsoft.EntityFrameworkCore;
using OnlineStore.Data.DbContexts;
using OnlineStore.Data.IRepositories.IBaseRepositories;
using OnlineStore.Domain.Common;
using System.Linq.Expressions;

namespace OnlineStore.Data.Repositories.BaseRepositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Auditable
    {
        protected readonly OnlineStoreDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;
        public GenericRepository()
        {
            _dbContext = new OnlineStoreDbContext();
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
            => (await _dbSet.AddAsync(entity)).Entity;

        public Task<bool> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return Task.FromResult(true);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null)
            => expression is null ? _dbSet : _dbSet.Where(expression);

        public Task<T> GetAsync(Expression<Func<T, bool>> expression)
            => _dbSet.FirstOrDefaultAsync(expression);

        public T Update(T entity)
            => _dbSet.Update(entity).Entity;
        public Task SaveChangesAsync()
            => _dbContext.SaveChangesAsync();
    }
}
