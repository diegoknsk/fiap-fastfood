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

        /*[HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }*/

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
            return created ? Ok() : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProductModel model)
        {
            if (model.Id != id) return BadRequest("ID mismatch.");
            var updated = await _service.UpdateAsync(model);
            return updated ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? Ok() : NotFound();
        }
    }

}
