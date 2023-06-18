using ECommerce.IdentityServer.Data;
using ECommerce.IdentityServer.Dtos;
using ECommerce.IdentityServer.Models;
using ECommerce.IdentityServer.Services.Interfaces;
using ECommerce.Shared.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.IdentityServer.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public AuthenticationService(ITokenService tokenService,
            UserManager<User> userManager,
            ApplicationDbContext context)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _context = context;
        }

        public async Task<ResponseDto<TokenDto>> CreateTokenAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return ResponseDto<TokenDto>.Fail("Email or Password is wrong", 400, true);
            }

            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                return ResponseDto<TokenDto>.Fail("Email or Password is wrong", 400, true);
            }

            var token = await _tokenService.CreateToken(user);

            var userRefreshToken = await _context.UserRefreshTokens.Where(p => p.UserId == user.Id).FirstOrDefaultAsync();
            if (userRefreshToken == null)
            {
                await _context.UserRefreshTokens.AddAsync(new UserRefreshToken
                {
                    UserId = user.Id,
                    Code = token.RefreshToken,
                    Expiration = token.RefreshTokenExpiration
                });
            }
            else
            {
                userRefreshToken.Code = token.RefreshToken;
                userRefreshToken.Expiration = token.RefreshTokenExpiration;
                _context.UserRefreshTokens.Update(userRefreshToken);
            }

            await _context.SaveChangesAsync();
            return ResponseDto<TokenDto>.Success(token, 200);
        }

        public async Task<ResponseDto<TokenDto>> CreateTokenByRefreshTokenAsync(string refreshToken)
        {
            var userRefreshToken = await _context.UserRefreshTokens.Where(p => p.Code == refreshToken).FirstOrDefaultAsync();

            if (userRefreshToken == null)
            {
                return ResponseDto<TokenDto>.Fail("RefreshToken Not Found", 404, true);
            }

            var user = await _userManager.FindByIdAsync(userRefreshToken.UserId.ToString());
            if (user == null)
            {
                return ResponseDto<TokenDto>.Fail("User Not Found", 404, true);
            }

            var tokenDto = await _tokenService.CreateToken(user);
            userRefreshToken.Code = tokenDto.RefreshToken;
            userRefreshToken.Expiration = tokenDto.RefreshTokenExpiration;

            _context.UserRefreshTokens.Update(userRefreshToken);
            await _context.SaveChangesAsync();

            return ResponseDto<TokenDto>.Success(tokenDto, 200);
        }

        public async Task<ResponseDto<NoContentDto>> RevokeRefreshTokenAsync(string refreshToken)
        {
            var userRefreshToken = await _context.UserRefreshTokens.Where(p => p.Code == refreshToken).FirstOrDefaultAsync();

            if (userRefreshToken == null)
            {
                return ResponseDto<NoContentDto>.Fail("RefreshToken Not Found", 404, true);
            }

            _context.UserRefreshTokens.Remove(userRefreshToken);
            await _context.SaveChangesAsync();

            return ResponseDto<NoContentDto>.Success(200);
        }
    }
}
