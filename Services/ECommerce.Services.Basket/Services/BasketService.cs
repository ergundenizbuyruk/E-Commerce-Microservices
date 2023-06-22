using AutoMapper;
using ECommerce.Services.Basket.Data;
using ECommerce.Services.Basket.Dtos;
using ECommerce.Services.Basket.Models;
using ECommerce.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Services.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BasketService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<BasketDto>> AddAsync(BasketCreateDto basketDto, Guid userId)
        {
            var basket = await _context.Baskets.Include(p => p.Products).FirstOrDefaultAsync(p => p.UserId == userId);

            if (basket == null)
            {
                var newBasket = _mapper.Map<Models.Basket>(basketDto);
                newBasket.UserId = userId;
                await _context.AddAsync(newBasket);
                await _context.SaveChangesAsync();
                return ResponseDto<BasketDto>.Success(_mapper.Map<BasketDto>(newBasket), 200);
            }
            else
            {
                foreach (var product in basketDto.Products)
                {
                    if (basket.Products.Select(p => p.ProductId).Contains(product.ProductId))
                    {
                        var productFromBasket = basket.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
                        productFromBasket!.Count += product.Count;
                    }
                    else
                    {
                        basket.Products.Add(new Product
                        {
                            Name = product.Name,
                            Price = product.Price,
                            ProductId = product.ProductId,
                            Count = product.Count
                        });
                    }
                }
                _context.Baskets.Update(basket);
                await _context.SaveChangesAsync();
                return ResponseDto<BasketDto>.Success(_mapper.Map<BasketDto>(basket), 200);
            }
        }

        public async Task<ResponseDto<BasketDto>> GetAsync(Guid userId)
        {
            var basket = await _context.Baskets.Include(p => p.Products).FirstOrDefaultAsync(p => p.UserId == userId);

            if (basket == null)
            {
                return ResponseDto<BasketDto>.Fail("Basket Not Found", 404, true);
            }

            return ResponseDto<BasketDto>.Success(_mapper.Map<BasketDto>(basket), 200);
        }
    }
}
