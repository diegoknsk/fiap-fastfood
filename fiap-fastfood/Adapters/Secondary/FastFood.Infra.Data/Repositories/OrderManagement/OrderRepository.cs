using FastFood.Domain.Entities.OrderManagement;
using FastFood.Domain.Ports.OrderManagement;
using FastFood.Infra.Data.Context;
using FastFood.Infra.Data.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FastFood.Infra.Data.Repositories.OrderManagement
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(FastFoodDbContext context) : base(context)
        {
        }

        public Task<bool> ExistsByCodeAsync(string code)
        {
            return _context.Orders.AnyAsync(o => o.Code == code);
        }

        public override Task<Order?> GetByIdAsync(Guid id, params Expression<Func<Order, object>>[] includes)
        {
            return base.GetByIdAsync(id, includes);
        }
    }
}
