using ECommerce.IdentityServer.Dtos;
using ECommerce.IdentityServer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : CustomBaseController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateRole(CreateRoleDto createRoleDto)
        {
            var result = await _roleService.CreateRoleAsync(createRoleDto);
            return ActionResultInstance(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRole(RoleDto roleDto)
        {
            var result = await _roleService.UpdateRoleAsync(roleDto);
            return ActionResultInstance(result);
        }
    }
}
