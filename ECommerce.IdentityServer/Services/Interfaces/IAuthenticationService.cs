using ECommerce.IdentityServer.Dtos;
using ECommerce.Shared.Dtos;

namespace ECommerce.IdentityServer.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ResponseDto<TokenDto>> CreateTokenAsync(LoginDto loginDto);

        Task<ResponseDto<TokenDto>> CreateTokenByRefreshTokenAsync(string refreshToken);

        Task<ResponseDto<NoContentDto>> RevokeRefreshTokenAsync(string refreshToken);
    }
}
