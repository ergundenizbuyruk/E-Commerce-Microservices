using AutoMapper;
using ECommerce.Services.Inventory.Dtos;
using ECommerce.Services.Inventory.Models;

namespace ECommerce.Services.Inventory.Mapping
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<Catalog, CatalogDto>().ReverseMap();
            CreateMap<Catalog, CatalogCreateDto>().ReverseMap();
            CreateMap<Catalog, CatalogUpdateDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();

        }
    }
}
