using System.Linq.Expressions;

namespace FastFood.Domain.Ports.Common
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(int page, int pageSize);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
