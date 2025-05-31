using FastFood.Application.Models.Common;
using FastFood.Application.Models.OrderManagement;
using FastFood.Application.Models.OrderManagement.FastFood.Application.Models.OrderManagement;
using FastFood.Application.Services.OrderManagement;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderAppService _orderAppService;

        public OrderController(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }

        [HttpPost("start")]
        public async Task<IActionResult> StartOrder([FromBody] OrderCustomerStartModel customer)
        {
            var orderId = await _orderAppService.StartOrderAsync(customer);
            return Ok(new ApiResponse<Guid>(orderId));
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProductToOrder([FromBody] AddProductToOrderModel model)
        {
            await _orderAppService.AddProductToOrderAsync(model);
            return Ok(new ApiResponse<string>("Produto adicionado com sucesso ao pedido."));
        }

        [HttpPut("product")]
        public async Task<IActionResult> UpdateProductInOrder([FromBody] UpdateProductInOrderModel model)
        {
            await _orderAppService.UpdateProductInOrderAsync(model);
            return Ok(new ApiResponse<string>("Produto do pedido atualizado com sucesso."));
        }

        [HttpDelete("product")]
        public async Task<IActionResult> RemoveProductFromOrder([FromBody] RemoveProductFromOrderModel model)
        {
            await _orderAppService.RemoveProductFromOrderAsync(model);
            return Ok(new ApiResponse<string>("Produto removido do pedido com sucesso."));
        }
    }
}
