using AutoMapper;
using Demo.Core.ViewModels;
using Demo.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Authorize(Roles = CustomRoles.User + "," + CustomRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService , IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        /// <summary>
        /// Add a new user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserViewModel model)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            var isUserCreated = await _userService.CreateUser(model);
            return isUserCreated ? HandleResponse(isUserCreated) : BadRequest();
        }

        [Route("AssignRole")]
        [HttpPost]
        public async Task<IActionResult> AssignRole(int userId, List<int> roleId)
        {
            var isRoleAssigned = await _userService.AssignRole(userId, roleId);
            return isRoleAssigned ? HandleResponse(isRoleAssigned) : BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int userId)
        {
            if(userId <= 0) { return BadRequest(); }
            {
                var isUserDeleted = await _userService.DeleteUser(userId);
                return isUserDeleted ? HandleResponse(isUserDeleted) : BadRequest();
            }
        }

    }
}
