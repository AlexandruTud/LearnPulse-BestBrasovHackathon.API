using Hackathon_Best_API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Hackathon_Best_API.Controllers
{
    [ApiController]
    [Route("api/getRole")]
    public class GetRoleController : ControllerBase
    {
        private readonly IGetUserRoleByIdService _getUserRoleByIdService;
        
        public GetRoleController(IGetUserRoleByIdService getUserRoleByIdService)
        {
            _getUserRoleByIdService = getUserRoleByIdService;
        }
        [HttpGet]
        public async Task<IActionResult> GetRole(int id)
        {
            var result = await _getUserRoleByIdService.GetUserRoleByIdAsync(id);
            if (result == 0)
            {
                return BadRequest();
            }
            Log.Information("Role :" + result);
            return Ok(result);
        }
    }
}
