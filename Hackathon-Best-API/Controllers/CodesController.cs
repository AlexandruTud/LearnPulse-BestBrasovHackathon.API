using Hackathon_Best_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon_Best_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CodesController : ControllerBase
    {
        private readonly ICodesRepository _codesRepository;
        public CodesController(ICodesRepository codesRepository)
        {
            _codesRepository = codesRepository;
        }
        [HttpPost]
        [Route("GenerateCourseCodes")]
        public async Task<IActionResult> GenerateCourseCodesAsync(int IdUser, int IdCourse)
        {
            var result = await _codesRepository.GenerateCourseCodesAsync(IdUser, IdCourse);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpGet]
        [Route("GetCodeByCourseId")]
        public async Task<IActionResult> GetCodeByCourseIdAsync(int IdCourse)
        {
            var result = await _codesRepository.GetCodeByCourseIdAsync(IdCourse);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
