using AutoMapper;
using Demo.Core.Models;
using Demo.Core.ViewModels;
using Demo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
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
            var isUserCreated = await _userService.CreateUser(model);
            return isUserCreated ? HandleResponse(isUserCreated) : BadRequest();
        }


    }
}
