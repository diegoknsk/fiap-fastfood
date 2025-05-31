using FastFood.Domain.Entities.OrderManagement;
using System.Linq.Expressions;

namespace FastFood.Domain.Ports.OrderManagement
{
    public interface IOrderRepository
    {
        Task<Order?> GetByIdAsync(Guid id);
        Task<Order?> GetByIdAsync(Guid id, params Expression<Func<Order, object>>[] includes);
        Task<Order?> GetByIdWithProductsAndIngredientsAsync(Guid id);

        Task<Order?> GetCompleteByIdAsync(Guid id);

        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task<bool> ExistsByCodeAsync(string code);
    }
}
