using AutoMapper;
using ECommerce.IdentityServer.Dtos;
using ECommerce.IdentityServer.Models;
using ECommerce.IdentityServer.Services.Interfaces;
using ECommerce.Shared.Dtos;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.IdentityServer.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;

        public RoleService(RoleManager<Role> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<ResponseDto<RoleDto>> CreateRoleAsync(CreateRoleDto roleDto)
        {
            var role = new Role
            {
                Name = roleDto.Name,
            };

            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(p => p.Description).ToList();
                return ResponseDto<RoleDto>.Fail(new ErrorDto(errors, true), 400);
            }

            return ResponseDto<RoleDto>.Success(_mapper.Map<RoleDto>(role), 200);
        }

        public async Task<ResponseDto<RoleDto>> UpdateRoleAsync(RoleDto roleDto)
        {
            var role = await _roleManager.FindByIdAsync(roleDto.Id.ToString());
            
            if (role == null)
            {
                return ResponseDto<RoleDto>.Fail(new ErrorDto("Role Not Found", true), 404);
            }

            role.Name = roleDto.Name;
            var result = await _roleManager.UpdateAsync(role);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(p => p.Description).ToList();
                return ResponseDto<RoleDto>.Fail(new ErrorDto(errors, true), 400);
            }

            return ResponseDto<RoleDto>.Success(_mapper.Map<RoleDto>(role), 200);
        }
    }
}
