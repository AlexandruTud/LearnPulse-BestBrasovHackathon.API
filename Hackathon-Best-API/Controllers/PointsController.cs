using Hackathon_Best_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon_Best_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PointsController : ControllerBase
    {
        private readonly IAddUserPointsRepository _addUserPointsRepository;
        public PointsController(IAddUserPointsRepository addUserPointsRepository)
        {
            _addUserPointsRepository = addUserPointsRepository;
        }
        [HttpPost]
        [Route("AddUserPoints")]
        public async Task<IActionResult> AddUserPointsAsync(int IdUser, int Points)
        {
            var result = await _addUserPointsRepository.AddUserPointsAsync(IdUser, Points);
            if (result != -1)
            {
                return BadRequest();
            }
            return Ok("Points Added");
        }
        [HttpGet]
        [Route("GetTopUsers")]
        public async Task<IActionResult> GetTopUsersAsync()
        {
            var result = await _addUserPointsRepository.GetTopUsersAsync();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
