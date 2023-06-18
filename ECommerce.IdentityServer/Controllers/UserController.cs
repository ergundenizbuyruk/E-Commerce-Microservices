using ECommerce.IdentityServer.Dtos;
using ECommerce.IdentityServer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.IdentityServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto userDto)
        {
            var result = await _userService.CreateUserAsync(userDto);
            return ActionResultInstance(result);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateUser(UpdateUserDto userDto)
        {
            var userName = User.Identity.Name;
            var result = await _userService.UpdateUserAsync(userName, userDto);
            return ActionResultInstance(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var result = await _userService.GetUserById(id);
            return ActionResultInstance(result);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserInSession()
        {
            var userName = User.Identity.Name;
            var result = await _userService.GetUserByUserName(userName);
            return ActionResultInstance(result);
        }

        [HttpGet("{userName}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            var result = await _userService.GetUserByUserName(userName);
            return ActionResultInstance(result);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUser()
        {
            var result = await _userService.GetAllUser();
            return ActionResultInstance(result);
        }

        [HttpPatch]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRoleToUser(AssignRoleToUser assignRoleDto)
        {
            var result = await _userService.AssignRoleToUserAsync(assignRoleDto.UserId, assignRoleDto.RoleName);
            return ActionResultInstance(result);
        }
    }
}
