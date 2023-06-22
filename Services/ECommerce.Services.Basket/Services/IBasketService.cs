using ECommerce.Services.Basket.Dtos;
using ECommerce.Shared.Dtos;

namespace ECommerce.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<ResponseDto<BasketDto>> GetAsync(Guid userId);
        Task<ResponseDto<BasketDto>> AddAsync(BasketCreateDto order, Guid userId);
    }
}
