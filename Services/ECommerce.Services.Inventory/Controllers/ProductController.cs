using ECommerce.Services.Inventory.Dtos;
using ECommerce.Services.Inventory.Models;
using ECommerce.Services.Inventory.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Services.Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomBaseController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAllAsync();
            return ActionResultInstance(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _productService.GetAsync(id);
            return ActionResultInstance(result);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductCreateDto product)
        {
            var result = await _productService.AddAsync(product);
            return ActionResultInstance(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteAsync(id);
            return ActionResultInstance(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto product)
        {
            var result = await _productService.UpdateAsync(product);
            return ActionResultInstance(result);
        }
    }
}
