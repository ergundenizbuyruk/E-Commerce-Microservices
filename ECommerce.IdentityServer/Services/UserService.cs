using AutoMapper;
using ECommerce.IdentityServer.Data;
using ECommerce.IdentityServer.Dtos;
using ECommerce.IdentityServer.Models;
using ECommerce.IdentityServer.Services.Interfaces;
using ECommerce.Shared.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.IdentityServer.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager, IMapper mapper, ApplicationDbContext context, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
            _roleManager = roleManager;
        }

        public async Task<ResponseDto<UserDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = new User
            {
                Name = createUserDto.Name,
                Surname = createUserDto.Surname,
                Email = createUserDto.Email,
                UserName = createUserDto.UserName
            };

            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if (!result.Succeeded)
            {
                var error = result.Errors.Select(p => p.Description).ToList();
                return ResponseDto<UserDto>.Fail(new ErrorDto(error, true), 400);
            }

            return ResponseDto<UserDto>.Success(_mapper.Map<UserDto>(user), 200);
        }

        public async Task<ResponseDto<UserDto>> GetUserById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return ResponseDto<UserDto>.Fail("User not found", 400, true);
            }

            return ResponseDto<UserDto>.Success(_mapper.Map<UserDto>(user), 200);
        }

        public async Task<ResponseDto<UserDto>> GetUserByUserName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null) 
            {
                return ResponseDto<UserDto>.Fail("User not found", 400, true);
            }

            return ResponseDto<UserDto>.Success(_mapper.Map<UserDto>(user), 200);
        }

        public async Task<ResponseDto<List<UserDto>>> GetAllUser()
        {
            var users = await _context.Users.ToListAsync();
            return ResponseDto<List<UserDto>>.Success(_mapper.Map<List<UserDto>>(users), 200);
        }

        public async Task<ResponseDto<UserDto>> UpdateUserAsync(string userName, UpdateUserDto updateUserDto)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return ResponseDto<UserDto>.Fail("User not found", 400, true);
            }

            user.Name = updateUserDto.Name;
            user.Surname = updateUserDto.Surname;
            user.Email = updateUserDto.Email;
            user.UserName = updateUserDto.UserName;
            user.BirthDate = updateUserDto.BirthDate;
            user.Gender = updateUserDto.Gender;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                var error = result.Errors.Select(p => p.Description).ToList();
                return ResponseDto<UserDto>.Fail(new ErrorDto(error, true), 400);
            }

            await _userManager.UpdateNormalizedEmailAsync(user);
            await _userManager.UpdateNormalizedUserNameAsync(user);
            await _userManager.UpdateSecurityStampAsync(user);

            await _context.SaveChangesAsync();
            return ResponseDto<UserDto>.Success(_mapper.Map<UserDto>(user), 200);
        }

        public async Task<ResponseDto<NoContentDto>> AssignRoleToUserAsync(Guid userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var role = await _roleManager.FindByNameAsync(roleName);

            if (user == null || user == null)
            {
                return ResponseDto<NoContentDto>.Fail("User or Role Not Found", 404, true);
            }

            var result = await _userManager.AddToRoleAsync(user, role!.Name!);

            if (!result.Succeeded)
            {
                var error = result.Errors.Select(p => p.Description).ToList();
                return ResponseDto<NoContentDto>.Fail(new ErrorDto(error, true), 400);
            }

            return ResponseDto<NoContentDto>.Success(new NoContentDto(), 200);
        }
    }
}
