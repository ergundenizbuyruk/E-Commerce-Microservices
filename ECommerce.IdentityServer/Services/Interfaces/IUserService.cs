using ECommerce.IdentityServer.Dtos;
using ECommerce.Shared.Dtos;

namespace ECommerce.IdentityServer.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResponseDto<UserDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<ResponseDto<UserDto>> UpdateUserAsync(string userName, UpdateUserDto updateeUserDto);
        Task<ResponseDto<UserDto>> GetUserByUserName(string userName);
        Task<ResponseDto<UserDto>> GetUserById(Guid id);
        Task<ResponseDto<NoContentDto>> AssignRoleToUserAsync(Guid userId, string roleName);
        Task<ResponseDto<List<UserDto>>> GetAllUser();
    }
}
