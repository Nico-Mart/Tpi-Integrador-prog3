using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IReviewRepository : IRepository
    {
        Review GetReviewById(int id);
        IEnumerable<Review> GetReviewsFromAlbunId(int albunId);
        void CreateReview(Review review);
        void UpdateReview(Review review);
        void DeleteReview(Review reviewId);
        IEnumerable<Review> GetAllReviews();
    }
}
