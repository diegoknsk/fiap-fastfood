using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using FastFood.Domain.Ports.Common;
using FastFood.Infra.Data.Context;

namespace FastFood.Infra.Data.Repositories.Common
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly FastFoodDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(FastFoodDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
                query = query.Include(include);

            return await query.FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id);
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
                query = query.Include(include);

            return await query.ToListAsync();
        }

        public virtual async Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(int page, int pageSize)
        {
            var total = await _dbSet.CountAsync();
            var items = await _dbSet.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return (items, total);
        }

        public virtual async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public virtual void Update(T entity) => _dbSet.Update(entity);

        public virtual Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public virtual void Remove(T entity) => _dbSet.Remove(entity);
    }
}
