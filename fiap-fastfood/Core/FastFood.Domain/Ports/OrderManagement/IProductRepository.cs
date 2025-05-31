using FastFood.Domain.Entities.OrderManagement;
using FastFood.Domain.Entities.OrderManagement.Ingredients;
using FastFood.Domain.Ports.Common;

namespace FastFood.Domain.Ports.OrderManagement
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<(IEnumerable<Product> Items, int TotalCount)> GetPagedAsync(ProductPaginationParameters parameters);
        Task<ProductBaseIngredient?> GetBaseIngredientByProductAsync(Guid productId, Guid ingredientId);

    }
}
