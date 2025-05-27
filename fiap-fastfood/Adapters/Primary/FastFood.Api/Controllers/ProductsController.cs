using FastFood.Application.Models.Common;
using FastFood.Application.Models.OrderManagement;
using FastFood.Application.Services.OrderManagement;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ProductFilterParameters filter)
        {
            var paged = await _service.GetPagedAsync(filter);
            return Ok(new PagedResponse<ProductModel>(paged));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductModel model)
        {
            var created = await _service.CreateAsync(model);

            if (!created)
                return BadRequest(ApiResponse<string>.Fail("Erro ao criar o produto."));

            return Ok(ApiResponse<string>.Ok(null, "Produto criado com sucesso."));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProductModel model)
        {
            if (model.Id != id)
                return BadRequest(ApiResponse<string>.Fail("O ID do modelo não corresponde ao da URL."));

            var updated = await _service.UpdateAsync(model);
            if (!updated)
                return NotFound(ApiResponse<string>.Fail("Produto não encontrado."));

            return Ok(ApiResponse<string>.Ok("Produto atualizado com sucesso."));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound(ApiResponse<string>.Fail("Produto não encontrado."));

            return Ok(ApiResponse<string>.Ok("Produto removido com sucesso."));
        }
    }

}
