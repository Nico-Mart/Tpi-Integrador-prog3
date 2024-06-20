using Application.Models;
using Domain.Entities;


namespace Application.Interfaces
{
    public interface IReviewService 
    {
        Review GetReviewById(int id);
        IEnumerable<Review> GetAllReviews();    
        public List<Review> GetReviewsFromAlbunId(int albunId);
        void CreateReview(ReviewDto reviewdto);
        void UpdateReview(int reviewId, ReviewDto reviewdto);
        void DeleteReview(int reviewId);
    }
}
