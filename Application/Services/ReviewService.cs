using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public ReviewService(IReviewRepository reviewRepository, IUserRepository userRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public void CreateReview(ReviewDto reviewdto)
        {
            var user = _userRepository.GetUserById(reviewdto.SubscriberId);
            reviewdto.SubcriberUserName = user.UserName;
            if (!string.IsNullOrEmpty(reviewdto.SubcriberUserName))
            {
                var ReviewNew = _mapper.Map<Review>(reviewdto);
                _reviewRepository.CreateReview(ReviewNew);
            }
            else
            {
                throw new InvalidOperationException("SubscriberUserName cannot be empty.");
            }
        }
        public void DeleteReview(int reviewId)
        {
            var Reviewdelete = _mapper.Map<Review>(reviewId);
            _reviewRepository.CreateReview(Reviewdelete);
        }
        public IEnumerable<Review> GetAllReviews()
        {
            return _reviewRepository.GetAllReviews();
        }

        public Review GetReviewById(int id)
        {
            return _reviewRepository.GetReviewById(id);
        }

        public List<Review> GetReviewsFromAlbunId(int albunId)
        {
            return _reviewRepository.GetReviewsFromAlbunId(albunId).ToList();
        }

        public void UpdateReview(int reviewId ,ReviewDto reviewdto)
        {
            var existsReview = _reviewRepository.GetReviewById(reviewId);
            if (existsReview == null)
            {
                throw new InvalidOperationException("Review not found");
            }
            existsReview.AlbunId = reviewdto.AlbunId;
            existsReview.SubscriberId = existsReview.SubscriberId;
            existsReview.SubcriberUserName = reviewdto.SubcriberUserName;
            existsReview.Description = reviewdto.Description;
            existsReview.Score = reviewdto.Score;
            existsReview.CreationDate = reviewdto.CreationDate;

            _reviewRepository.UpdateReview(existsReview);
        }
    }
}
