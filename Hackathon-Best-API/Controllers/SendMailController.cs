using Hackathon_Best_API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Hackathon_Best_API.Controllers
{
    [ApiController]
    [Route("api/sendMail")]
    public class SendMailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        
        public SendMailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost]
        public IActionResult SendMail(string to, string subject, string body)
        {
            var result = _emailService.SendEmail(to, subject, body);
            Log.Information("Mail Sent" + result);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

    }
}
