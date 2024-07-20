using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class ReviewRepository : Repository, IReviewRepository
    {
        public ReviewRepository(AlbunsContext context) : base(context) 
        { 
        }
        public Review GetReviewById(int reviewid)
        {
            return _context.Reviews.Find(reviewid);
        }
        public IEnumerable<Review> GetReviewsFromAlbunId(int albunId)
        {
            return _context.Reviews.Where(r => r.AlbunId == albunId).ToList();
        }

        public void CreateReview(Review review)
        {
            _context.Reviews.Add(review);
            SaveChanges();
        }
        public void UpdateReview(Review review)
        {
            _context.Reviews.Update(review);
            SaveChanges();
        }

        public void DeleteReview(Review reviewId)
        {
            var reviewToDelete = _context.Reviews.Find(reviewId);
            if (reviewToDelete != null)
            {
                _context.Reviews.Remove(reviewToDelete);
                SaveChanges();
            }
        }
        public IEnumerable<Review> GetAllReviews()
        {
            return _context.Reviews.ToList();
        }

    }
}
