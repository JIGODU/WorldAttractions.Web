using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WorldAttractionsExplorer.DataAccess.DTOs;
using WorldAttractionsExplorer.Services.Contracts;

namespace WorldAttractionsExplorer.Controllers
{
    [Route("api/v1/reviews")]
    [ApiController]
    public class ReviewsController(IReviewContract reviewService) : ControllerBase
    {

        [HttpGet("attraction/{attractionId}")]
        public async Task<IActionResult> GetReviewsForAttraction(int attractionId)
        {
            var reviews = await reviewService.GetReviewsForAttraction(attractionId);
            return Ok(reviews);
        }

        [Authorize(Policy = "GuideOrAbove")]
        [HttpPost("add")]
        public async Task<IActionResult> AddReview([FromBody] ReviewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var success = await reviewService.AddReview(userId, model);

            return success ? Ok(new { message = "Review added successfully!" }) : BadRequest("Failed to add review.");
        }

        [Authorize(Policy = "GuideOrAbove")]
        [HttpPut("edit/{reviewId}")]
        public async Task<IActionResult> EditReview(int reviewId, [FromBody] ReviewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var success = await reviewService.EditReview(reviewId, userId, model);

            return success ? Ok(new { message = "Review updated successfully!" }) : Forbid("You can only edit your own reviews.");
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("delete/{reviewId}")]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            var success = await reviewService.DeleteReview(reviewId);
            return success ? Ok(new { message = "Review deleted successfully!" }) : NotFound("Review not found.");
        }
    }
}
