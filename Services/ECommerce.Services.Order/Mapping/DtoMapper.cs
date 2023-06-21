using AutoMapper;
using ECommerce.Services.Order.Dtos;
using ECommerce.Services.Order.Models;

namespace ECommerce.Services.Order.Mapping
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<Models.Order, OrderDto>()
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.getTotalPrice()))
            .ForMember(dest => dest.ProductOrders, opt => opt.MapFrom(src => src.ProductOrders));
            CreateMap<OrderDto, Models.Order>().ReverseMap();

            CreateMap<ProductOrder, ProductOrderDto>();
            CreateMap<ProductOrderDto, ProductOrder>();
            CreateMap<Models.Order, OrderCreateDto>().ReverseMap();
            CreateMap<Models.Order, OrderUpdateDto>().ReverseMap();
        }
    }
}
