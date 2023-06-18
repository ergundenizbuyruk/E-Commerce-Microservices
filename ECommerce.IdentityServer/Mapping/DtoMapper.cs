using AutoMapper;
using ECommerce.IdentityServer.Dtos;
using ECommerce.IdentityServer.Models;

namespace ECommerce.IdentityServer.Mapping
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
        }
    }
}
