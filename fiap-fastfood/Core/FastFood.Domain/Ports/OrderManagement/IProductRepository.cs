using FastFood.Domain.Entities.OrderManagement;

namespace FastFood.Domain.Ports.OrderManagement
{
    public interface IProductRepository
    {
        IEnumerable<Product> ListAll();
    }
}
