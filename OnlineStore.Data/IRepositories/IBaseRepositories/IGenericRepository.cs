using OnlineStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
