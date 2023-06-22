using AutoMapper;
using ECommerce.Services.Order.Data;
using ECommerce.Services.Order.Dtos;
using ECommerce.Services.Order.Services.Interfaces;
using ECommerce.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Services.Order.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<OrderDto>> AddAsync(OrderCreateDto orderCreateDto, Guid userId)
        {
            var order = _mapper.Map<Models.Order>(orderCreateDto);
            order.UserId = userId;
            order.OrderDate = DateTime.Now;

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return ResponseDto<OrderDto>.Success(_mapper.Map<OrderDto>(order), 200);
        }

        public async Task<ResponseDto<NoContentDto>> DeleteAsync(int orderId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == orderId);

            if (order == null)
            {
                return ResponseDto<NoContentDto>.Fail("Order Not Found", 404, true);
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return ResponseDto<NoContentDto>.Success(200);
        }

        public async Task<ResponseDto<List<OrderDto>>> GetAllAsync()
        {
            var orders = await _context.Orders.Include(o => o.ProductOrders).ToListAsync();

            return ResponseDto<List<OrderDto>>.Success(_mapper.Map<List<OrderDto>>(orders), 200);
        }

        public async Task<ResponseDto<List<OrderDto>>> GetAllByUserAsync(Guid userId)
        {
            var orders = await _context.Orders.Include(o => o.ProductOrders).Where(p => p.UserId == userId).ToListAsync();

            return ResponseDto<List<OrderDto>>.Success(_mapper.Map<List<OrderDto>>(orders), 200);
        }

        public async Task<ResponseDto<OrderDto>> GetAsync(int id)
        {
            var order = await _context.Orders.Include(o => o.ProductOrders).FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
            {
                return ResponseDto<OrderDto>.Fail("Order Not Found", 404, true);
            }

            return ResponseDto<OrderDto>.Success(_mapper.Map<OrderDto>(order), 200);
        }

        public async Task<ResponseDto<OrderDto>> UpdateAsync(OrderUpdateDto orderUpdateDto)
        {
            var orderFromDb = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderUpdateDto.Id);
            if (orderFromDb == null)
            {
                return ResponseDto<OrderDto>.Fail("Order Not Found", 404, true);
            }
            orderFromDb.Status = orderUpdateDto.Status;

            _context.Orders.Update(orderFromDb);
            await _context.SaveChangesAsync();

            return ResponseDto<OrderDto>.Success(_mapper.Map<OrderDto>(orderFromDb), 200);
        }
    }
}
