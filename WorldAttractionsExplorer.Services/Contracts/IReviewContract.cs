using WorldAttractionsExplorer.DataAccess.DTOs;

namespace WorldAttractionsExplorer.Services.Contracts
{
    public interface IReviewContract
    {
        Task<List<ReviewModel>> GetReviewsForAttraction(int attractionId);

        Task<bool> AddReview(string userId, ReviewModel model);

        Task<bool> EditReview(int reviewId, string userId, ReviewModel model);

        Task<bool> DeleteReview(int reviewId);
    }
}
