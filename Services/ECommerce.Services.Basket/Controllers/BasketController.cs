using ECommerce.Services.Basket.Dtos;
using ECommerce.Services.Basket.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce.Services.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : CustomBaseController
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var response = await _basketService.GetAsync(userId);
            return ActionResultInstance(response);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(BasketCreateDto basket)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var response = await _basketService.AddAsync(basket, userId);
            return ActionResultInstance(response);
        }
    }
}
