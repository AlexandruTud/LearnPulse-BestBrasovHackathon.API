using Hackathon_Best_API.Interfaces;
using Hackathon_Best_API.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon_Best_API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesRepository _coursesRepository;
        public CoursesController(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }
        
        [HttpGet]
        [Route("GetAllPublicCourses")]
        public async Task<IActionResult> GetAllPublicCoursesAsync()
        {
            var result = await _coursesRepository.GetAllPublicCoursesAsync();
            return Ok(result);
        }
        
        [HttpGet]
        [Route("GetCoursesByTitle")]
        public async Task<IActionResult> GetCoursesByTitleAsync(string Title)
        {
            var result = await _coursesRepository.GetCoursesByTitleAsync(Title);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("InsertCourses")]
        public async Task<IActionResult> InsertCoursesAsync(CoursesRequest coursesRequest)
        {
            var result = await _coursesRepository.InsertCoursesAsync(coursesRequest);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
