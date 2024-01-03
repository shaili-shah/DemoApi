using Demo.Core.ViewModels;
using Demo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private IUserService _userService;
        private IJWTService _jwtService;

        public AuthController(IUserService userService, IJWTService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        /// <summary>
        /// Get token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _userService.AuthenticateUser(model);
            if (user != null)
            {
                var token = _jwtService.GenerateJwtToken(user);
                return HandleResponse(token);
            }
            else
            {
                return BadRequest("Invalid credentials");
            }
        }

       


    }
}
