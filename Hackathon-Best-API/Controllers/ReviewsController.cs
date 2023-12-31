﻿using Hackathon_Best_API.Interfaces;
using Hackathon_Best_API.Requests;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Hackathon_Best_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly IAddCourseReviewRepository _addCourseReviewRepository;
        public ReviewsController(IAddCourseReviewRepository addCourseReviewRepository)
        {
            _addCourseReviewRepository = addCourseReviewRepository;
        }
        [HttpPost]
        [Route("AddCourseReview")]
        public async Task<IActionResult> AddCourseReviewAsync([FromBody] AddCourseReviewRequest request)
        {
            var result = await _addCourseReviewRepository.AddCourseReviewAsync(request.IdUser, request.IdCourse, request.Review);
            Log.Information("Review :" + request);
            Log.Information("Review Added" + result);
            if (result != -1)
            {
                return BadRequest();
            }
            return Ok("Review Added");
        }
        [HttpGet]
        [Route("GetComments")]
        public async Task<IActionResult> GetCommentsAsync(int IdCourse)
        {
            var result = await _addCourseReviewRepository.GetCommentsAsync(IdCourse);
            Log.Information("Comments :" + result);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("AddCourseComment")]
        public async Task<IActionResult> AddCourseCommentAsync([FromBody] AddCourseCommentRequest request)
        {
            var result = await _addCourseReviewRepository.AddCourseCommentAsync(request.IdUser, request.IdCourse, request.Comment);
            Log.Information("Comment :" + request);
            Log.Information("Comment Added" + result);
            if (result != -1)
            {
                return BadRequest();
            }
            return Ok("Comment Added");
        }
    }
}
