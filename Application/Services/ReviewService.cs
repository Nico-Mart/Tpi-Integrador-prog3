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
        private readonly IOperationResultService _operationResultService;
        public ReviewService(IReviewRepository reviewRepository, IUserRepository userRepository, IMapper mapper, IOperationResultService operationResultService)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _operationResultService = operationResultService;
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
                _operationResultService.CreateFailureResult("SubscriberUserName cannot be empty.");
            }

        }
        public bool DeleteReview(int reviewId)
        {
            var review = _reviewRepository.GetReviewById(reviewId);
            if (review != null)
            {
                _reviewRepository.DeleteReview(review);
                _reviewRepository.SaveChanges();
                return true;
            }
            _operationResultService.CreateFailureResult("Review not found");
            return false;
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
                _operationResultService.CreateFailureResult("Review not found");
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
