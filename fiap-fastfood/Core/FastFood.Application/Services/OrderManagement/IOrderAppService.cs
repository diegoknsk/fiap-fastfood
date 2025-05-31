using FastFood.Application.Models.OrderManagement;
using FastFood.Application.Models.OrderManagement.FastFood.Application.Models.OrderManagement;

namespace FastFood.Application.Services.OrderManagement
{
    public interface IOrderAppService
    {
        Task<Guid> StartOrderAsync(OrderCustomerStartModel customer);
        Task AddProductToOrderAsync(AddProductToOrderModel model);
        Task UpdateProductInOrderAsync(UpdateProductInOrderModel model);
        Task RemoveProductFromOrderAsync(RemoveProductFromOrderModel model);
    }
}
