using FastFood.Application.Models.Common;
using FastFood.Application.Models.OrderManagement;

namespace FastFood.Application.Services.OrderManagement
{
    public interface IProductService
    {

        Task<IEnumerable<ProductModel>> GetAllAsync();
        Task<PagedList<ProductModel>> GetPagedAsync(ProductFilterParameters filter);

        Task<ProductModel?> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(ProductModel model);
        Task<bool> UpdateAsync(ProductModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}
