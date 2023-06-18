using ECommerce.IdentityServer.Dtos;
using ECommerce.Shared.Dtos;

namespace ECommerce.IdentityServer.Services.Interfaces
{
    public interface IRoleService
    {
        Task<ResponseDto<RoleDto>> CreateRoleAsync(CreateRoleDto roleDto);

        Task<ResponseDto<RoleDto>> UpdateRoleAsync(RoleDto roleDto);
    }
}
