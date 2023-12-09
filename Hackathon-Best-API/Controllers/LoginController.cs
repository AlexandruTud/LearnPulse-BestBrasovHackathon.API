using Hackathon_Best_API.DTOs;
using Hackathon_Best_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon_Best_API.Controllers
{

    [ApiController]
    [Route("api/Login")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO userLogin)
        {
            var result = await _loginService.Login(userLogin);
            if (result == -1)
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
