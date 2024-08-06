using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tpi_Integrador_prog3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("GetReviews")]
        [Authorize("All")]
        public IActionResult GetAllReviews()
        {
            return Ok(_reviewService.GetAllReviews());
        }
        [HttpGet("GetReview/{reviewId}")]
        [Authorize("All")]
        public IActionResult GetReviewById([FromRoute] int reviewId)
        {
            if (_reviewService.GetReviewById(reviewId) == null)
            {
                return BadRequest("The review does not exist");
            }
            return Ok(_reviewService.GetReviewById(reviewId));
        }
        [HttpPost("CreateReview")]
        [Authorize("Subscriber")]
        public IActionResult CreateReview([FromBody] ReviewDto reviewDto)
        {
            var result =_reviewService.CreateReview(reviewDto);

            if (result.Success)
            {
                return Ok(result.Message);   
            } 
            return BadRequest(result.Message);
        }
        [HttpDelete("DeeleteReview/{reviewId}")]
        [Authorize("Subscriber")]
        public IActionResult DeleteReview([FromRoute] int reviewId)
        {
            if (_reviewService.GetReviewById(reviewId) == null)
            {
                return BadRequest("The Albun does not exist");
            };
            _reviewService.DeleteReview(reviewId);
            return Ok("Delete success");
        }
        [HttpPut("UpdateReview/{reviewId}")]
        [Authorize("Subscriber")]
        public IActionResult UpdateReview([FromRoute] int reviewId, [FromBody] ReviewDto reviewdto)
        {
            var result = _reviewService.UpdateReview(reviewId, reviewdto); 
            if (result.Success)
            {
            _reviewService.UpdateReview(reviewId, reviewdto);
            return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
