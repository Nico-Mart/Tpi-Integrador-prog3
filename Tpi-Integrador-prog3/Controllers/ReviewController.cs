using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tpi_Integrador_prog3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("GetReviews")]
        public IActionResult GetReviews()
        {
            return Ok(_reviewService.GetAllReviews());
        }
        [HttpGet("GetReview/{reviewId}")]
        public IActionResult GetReview([FromRoute] int reviewId)
        {
            if (_reviewService.GetReviewById(reviewId) == null)
            {
                return BadRequest("The review does not exist");
            }
            return Ok(_reviewService.GetReviewById(reviewId));
        }
        [HttpPost("CreateReview")]
        public IActionResult CreateReview([FromBody] ReviewDto reviewDto)
        {

            _reviewService.CreateReview(reviewDto);
            return StatusCode(201);
        }
        [HttpDelete("DeeleteReview")]
        public IActionResult DeleteReview([FromRoute] int reviewid)
        {
            _reviewService.DeleteReview(reviewid);
            return Ok("Delete success");
        }
        [HttpPut("UpdateReview/{reviewId}")]
        public IActionResult UpdateReview([FromRoute] int reviewId, [FromBody] ReviewDto reviewdto)
        {
            if (_reviewService.GetReviewById(reviewId) == null)
            {
                return BadRequest("The review does not exist");
            }
            _reviewService.UpdateReview(reviewId, reviewdto);
            return Ok("Review Updated");
        }
    }
}
