using ECommerce.Services.Inventory.Dtos;
using ECommerce.Services.Inventory.Models;
using ECommerce.Services.Inventory.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Services.Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : CustomBaseController
    {
        private readonly ICatalogService _catalogService;
        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _catalogService.GetAllAsync();
            return ActionResultInstance(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _catalogService.GetAsync(id);
            return ActionResultInstance(result);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add([FromBody] CatalogCreateDto catalog)
        {
            var result = await _catalogService.AddAsync(catalog);
            return ActionResultInstance(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _catalogService.DeleteAsync(id);
            return ActionResultInstance(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(CatalogUpdateDto catalogDto)
        {
            var result = await _catalogService.UpdateAsync(catalogDto);
            return ActionResultInstance(result);
        }
    }
}
