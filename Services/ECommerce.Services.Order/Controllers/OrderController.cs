using ECommerce.Services.Order.Dtos;
using ECommerce.Services.Order.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Services.Order.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : CustomBaseController
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _orderService.GetAllAsync();
            return ActionResultInstance(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _orderService.GetAsync(id);
            return ActionResultInstance(result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllByUser(int userId)
        {
            var result = await _orderService.GetAllByUserAsync(userId);
            return ActionResultInstance(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] OrderCreateDto order)
        {
            var result = await _orderService.AddAsync(order);
            return ActionResultInstance(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _orderService.DeleteAsync(id);
            return ActionResultInstance(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(OrderUpdateDto order)
        {
            var result = await _orderService.UpdateAsync(order);
            return ActionResultInstance(result);
        }
    }
}
