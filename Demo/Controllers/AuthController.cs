using Demo.Core.ViewModels;
using Demo.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
