using Hackathon_Best_API.DTOs;
using Hackathon_Best_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon_Best_API.Controllers
{
    [ApiController]
    [Route("api/Register")]
    public class RegisterController  : ControllerBase
    {
        private readonly IRegisterService _registerService;
        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDTO userRegisterDTO)
        {
            var result = await _registerService.RegisterUserAsync(userRegisterDTO);
            if (result == -1)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
