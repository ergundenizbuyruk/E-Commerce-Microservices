using ECommerce.IdentityServer.Dtos;
using ECommerce.IdentityServer.Models;

namespace ECommerce.IdentityServer.Services.Interfaces
{
    public interface ITokenService
    {
        Task<TokenDto> CreateToken(User user);
    }
}
