using FastFood.Application.Mappers.CustomerIdentification;
using FastFood.Application.Models.Common;
using FastFood.Application.Models.CustomerIdentification;
using FastFood.Application.Services.CustomerIdentification;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        [HttpPost("identify")]
        public async Task<ActionResult<ApiResponse<CustomerModel>>> Identify([FromBody] CustomerIdentifyModel request)
        {
            var customer = await _customerAppService.IdentifyByCpfAsync(request.Cpf);
            return Ok(ApiResponse<CustomerModel>.Ok(customer.ToModel()));
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse<CustomerModel>>> Register([FromBody] CustomerRegisterModel request)
        {
            var customer = await _customerAppService.RegisterCustomerAsync(request.Name, request.Email, request.Cpf);
            return Ok(ApiResponse<CustomerModel>.Ok(customer.ToModel()));
        }

        [HttpPost("anonymous")]
        public async Task<ActionResult<ApiResponse<CustomerModel>>> RegisterAnonymous()
        {
            var customer = await _customerAppService.RegisterAnonymousAsync();
            return Ok(ApiResponse<CustomerModel>.Ok(customer.ToModel()));
        }
    }
}
