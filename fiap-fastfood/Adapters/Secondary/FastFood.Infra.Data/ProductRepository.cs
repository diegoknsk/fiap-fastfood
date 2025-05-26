using FastFood.Domain.Entities.OrderManagement;
using FastFood.Domain.Entities.OrderManagement.ValueObjects;
using FastFood.Domain.Ports.OrderManagement;
using FastFood.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Infra.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly FastFoodDbContext _context;

        public ProductRepository(FastFoodDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Product> ListAll()
        {
            return _context.Products
                .Include(p => p.Ingredients)
                .ToList();
        }
    }
}
