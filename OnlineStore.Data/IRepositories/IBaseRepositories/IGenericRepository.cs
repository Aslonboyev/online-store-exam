using OnlineStore.Domain.Common;
using System.Linq.Expressions;

namespace OnlineStore.Data.IRepositories.IBaseRepositories
{
    public interface IGenericRepository<T> where T : Auditable
    {
        Task<T> CreateAsync(T entity);

        T Update(T entity);

        Task<bool> DeleteAsync(T entity);

        IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null);

        Task<T> GetAsync(Expression<Func<T, bool>> expression);

        Task SaveChangesAsync();
    }
}
