using Hackathon_Best_API.Interfaces;
using Hackathon_Best_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Hackathon_Best_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IGetUserByIdRepository _userRepository;
        public UserController(IGetUserByIdRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var result = await _userRepository.GetUserByIdAsync(id);
            Log.Information("User :" + result);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

    }
}
