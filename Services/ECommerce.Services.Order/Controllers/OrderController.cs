using ECommerce.Services.Order.Dtos;
using ECommerce.Services.Order.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _orderService.GetAllAsync();
            return ActionResultInstance(result);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _orderService.GetAsync(id);
            return ActionResultInstance(result);
        }

        [HttpGet("{userId}")]
        [Authorize]
        public async Task<IActionResult> GetAllByUser()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await _orderService.GetAllByUserAsync(userId);
            return ActionResultInstance(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] OrderCreateDto order)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await _orderService.AddAsync(order, userId);
            return ActionResultInstance(result);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update(OrderUpdateDto order)
        {
            var result = await _orderService.UpdateAsync(order);
            return ActionResultInstance(result);
        }
    }
}
