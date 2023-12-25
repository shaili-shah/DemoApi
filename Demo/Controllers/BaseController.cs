using Demo.Common;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult HandleResponse<T>(T data, string successMessage = "Succeeded")
        {
            var response = new ApiResponse<T>
            {
                Success = true,
                Message = successMessage,
                Data = data
            };

            return Ok(response);
        }
    }
}
