using FastFood.Application.Models.Common;
using FastFood.Application.Models.OrderManagement;
using FastFood.Domain.Entities.OrderManagement;
using FastFood.Domain.Ports.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
