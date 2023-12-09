using Hackathon_Best_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon_Best_API.Controllers
{
    [ApiController]
    [Route("api/getCategories")]
    public class GetCategoriesController : ControllerBase
    {
        private readonly IGetRandomCategoriesRepository _getRandomCategoriesRepository;
        public GetCategoriesController(IGetRandomCategoriesRepository getRandomCategoriesRepository)
        {
            _getRandomCategoriesRepository = getRandomCategoriesRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            var result = await _getRandomCategoriesRepository.GetCategoriesAsync();
            return Ok(result);
        }
    }
}
