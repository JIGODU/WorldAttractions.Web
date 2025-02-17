using Microsoft.EntityFrameworkCore;
using WorldAttractionsExplorer.DataAccess;
using WorldAttractionsExplorer.DataAccess.DTOs;
using WorldAttractionsExplorer.DataAccess.Models;
using WorldAttractionsExplorer.Services.Contracts;

namespace WorldAttractionsExplorer.Services.Access
{
    public class ReviewService(ServerDbContext context) : IReviewContract
    {
        private readonly ServerDbContext _context = context;

        public async Task<List<ReviewModel>> GetReviewsForAttraction(int attractionId)
        {
            return await _context.Reviews
                .Where(r => r.AttractionId == attractionId)
                .Include(r => r.Author)
                .Select(r => new ReviewModel
                {
                    ReviewId = r.ReviewId,
                    AuthorUserName = r.Author.UserName,
                    Rating = r.Rating,
                    Description = r.Description,
                    PublishingDate = r.PublishingDate,
                })
                .ToListAsync();
        }

        public async Task<bool> AddReview(string userId, ReviewModel model)
        {
            var review = new Reviews
            {
                AuthorId = userId,
                AttractionId = model.AttractionId,
                Rating = model.Rating,
                Title = model.Title,
                Description = model.Description,
                PublishingDate = DateTime.UtcNow
            };

            _context.Reviews.Add(review);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EditReview(int reviewId, string userId, ReviewModel model)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            if (review == null || review.AuthorId != userId)
                return false;

            review.Rating = model.Rating;
            review.Title = model.Title;
            review.Description = model.Description;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteReview(int reviewId)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            if (review == null) return false;

            _context.Reviews.Remove(review);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
