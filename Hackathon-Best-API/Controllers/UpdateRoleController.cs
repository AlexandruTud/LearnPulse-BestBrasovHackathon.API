using Hackathon_Best_API.Interfaces;
using Hackathon_Best_API.Requests;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Hackathon_Best_API.Controllers
{
    [ApiController]
    [Route("api/updateRole")]
    public class UpdateRoleController : ControllerBase
    {
        private readonly IUpdateRoleService _updateRoleService;

        public UpdateRoleController(IUpdateRoleService updateRoleService)
        {
            _updateRoleService = updateRoleService;
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleRequest request)
        {
            var response = await _updateRoleService.ChangeRolesAsync(request);
            Log.Information("Role :" + request);    
            if (response == false)
            {
                return BadRequest("Error");
            }
            return Ok(response);
        }
    }
}
