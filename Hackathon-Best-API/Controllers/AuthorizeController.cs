using Hackathon_Best_API.Interfaces;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Hackathon_Best_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizeController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IGetUserRoleByIdService _getUserRoleByIdService;   
        public AuthorizeController(IConfiguration config, IGetUserRoleByIdService getUserRoleByIdService)
        {
            _config = config;
            _getUserRoleByIdService = getUserRoleByIdService;

        }

        [HttpPost]
        public IActionResult Post([FromBody] int IdUser)
        {
            var result = _getUserRoleByIdService.GetUserRoleByIdAsync(IdUser);
            if (result.Result == 3)
            {


                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
                  _config["Jwt:Issuer"],
                  null,
                  expires: DateTime.Now.AddMinutes(120),
                  signingCredentials: credentials);

                var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

                return Ok("Token : "+token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
