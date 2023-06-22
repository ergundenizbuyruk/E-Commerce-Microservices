using ECommerce.Services.Order.Dtos;
using ECommerce.Shared.Dtos;

namespace ECommerce.Services.Order.Services.Interfaces
{
    public interface IOrderService
    {
        Task<ResponseDto<List<OrderDto>>> GetAllAsync();
        Task<ResponseDto<List<OrderDto>>> GetAllByUserAsync(Guid userId);
        Task<ResponseDto<OrderDto>> GetAsync(int id);
        Task<ResponseDto<OrderDto>> AddAsync(OrderCreateDto order, Guid userId);
        Task<ResponseDto<NoContentDto>> DeleteAsync(int orderId);
        Task<ResponseDto<OrderDto>> UpdateAsync(OrderUpdateDto order);
    }
}
