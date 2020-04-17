using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AdminPro.Core.Entities;

namespace AdminPro.Core.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(params object[] id);

        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);

        Task<IReadOnlyList<T>> ListAllAsync(params Expression<Func<T, object>>[] includes);
        Task<List<T>> AddRangeAsync(List<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] includes);

        IEnumerable<T> GetWithRawSql(string query,
            params object[] parameters);

        Task<bool> ExistsAsync(Guid id);
    }
}
