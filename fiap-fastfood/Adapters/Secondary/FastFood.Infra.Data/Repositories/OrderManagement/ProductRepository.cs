using FastFood.Domain.Entities.OrderManagement;
using FastFood.Domain.Entities.OrderManagement.Ingredients;
using FastFood.Domain.Ports.OrderManagement;
using FastFood.Infra.Data.Context;
using FastFood.Infra.Data.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FastFood.Infra.Data.Repositories.OrderManagement
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(FastFoodDbContext context) : base(context)
        {
        }

        public async Task<(IEnumerable<Product>, int)> GetPagedAsync(ProductPaginationParameters parameters)
        {
            var query = _context.Products
                .Include(p => p.Ingredients)
                .AsQueryable();

            if (parameters.Category.HasValue)
            {
                query = query.Where(p => (int)p.Category == parameters.Category.Value);
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public override async Task<Product?> GetByIdAsync(Guid id, params Expression<Func<Product, object>>[] includes)
        {
            return await _dbSet
                .Include(p => p.Ingredients)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ProductBaseIngredient?> GetBaseIngredientByProductAsync(Guid productId, Guid ingredientId)
        {
            var product = await _context.Products
                .Include(p => p.Ingredients)
                .FirstOrDefaultAsync(p => p.Id == productId);

            return product?.Ingredients
                .FirstOrDefault(i => i.Id == ingredientId);
        }
    }
}
