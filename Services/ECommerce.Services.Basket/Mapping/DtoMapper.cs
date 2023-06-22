using AutoMapper;
using ECommerce.Services.Basket.Dtos;
using ECommerce.Services.Basket.Models;

namespace ECommerce.Services.Basket.Mapping
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<Models.Basket, BasketDto>().ReverseMap();
            CreateMap<Models.Basket, BasketCreateDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductCreateDto>().ReverseMap();
        }
    }
}
