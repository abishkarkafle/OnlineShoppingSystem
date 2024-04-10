using Microsoft.EntityFrameworkCore;
using OnlineShoppingSystem.Data;
using OnlineShoppingSystem.Interface;
using OnlineShoppingSystem.Models;
namespace OnlineShoppingSystem.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly OnlineShoppingSystemContext _context;

        public ReviewRepository(OnlineShoppingSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Review>> GetReviews()
        {
            return await _context.Review.ToListAsync();
        }

        public async Task<Review> GetReview(int id)
        {
            return await _context.Review.FindAsync(id);
        }

        public async Task PutReview(int id, Review Review)
        {
            if (id != Review.Id)
            {
                throw new ArgumentException("Id mismatch");
            }

            _context.Entry(Review).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Review> PostReview(Review Review)
        {
            _context.Review.Add(Review);
            await _context.SaveChangesAsync();
            return Review;
        }

        public async Task DeleteReview(int id)
        {
            var Review = await _context.Review.FindAsync(id);
            _context.Review.Remove(Review);
            await _context.SaveChangesAsync();
        }

        public bool ReviewExists(int id) // Implemented method
        {
            return _context.Review.Any(e => e.Id == id);
        }
    }
}
