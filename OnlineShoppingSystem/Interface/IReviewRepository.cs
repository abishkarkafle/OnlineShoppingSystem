using OnlineShoppingSystem.Models;

namespace OnlineShoppingSystem.Interface
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetReviews();
        Task<Review> GetReview(int id);
        Task PutReview(int id, Review shipping);
        Task<Review> PostReview(Review shipping);
        Task DeleteReview(int id);
        bool ReviewExists(int id);
    }
}
