using Application.Common;
using Application.Models;
using Domain.Entities;


namespace Application.Interfaces
{
    public interface IReviewService 
    {
        ReviewDto GetReviewById(int id);
        IEnumerable<ReviewDto> GetAllReviews();    
        public List<ReviewDto> GetReviewsFromAlbunId(int albunId);
        OperationResult CreateReview(ReviewDto reviewdto);
        OperationResult UpdateReview(int reviewId, ReviewDto reviewdto);
        bool DeleteReview(int reviewId);
    }
}
