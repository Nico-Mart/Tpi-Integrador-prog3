using Application.Common;
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

        public OperationResult CreateReview(ReviewDto reviewDto)
        {
            var user = _userRepository.GetUserById(reviewDto.SubscriberId);
            reviewDto.SubcriberUserName = user.UserName;
            if (!string.IsNullOrEmpty(reviewDto.SubcriberUserName))
            {
                var newReview = _mapper.Map<Review>(reviewDto);
                _reviewRepository.CreateReview(newReview);
                return _operationResultService.CreateSuccessResult("Review Created");
            }
            else
            {
                return _operationResultService.CreateFailureResult("SubscriberUserName cannot be empty.");
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
        public IEnumerable<ReviewDto> GetAllReviews()
        {
            var getReview = _reviewRepository.GetAllReviews();
            return _mapper.Map<IEnumerable<ReviewDto>>(getReview);
        }

        public ReviewDto GetReviewById(int id)
        {
            var getReview = _reviewRepository.GetReviewById(id);
            return _mapper.Map<ReviewDto>(getReview);
        }

        public List<ReviewDto> GetReviewsFromAlbunId(int albunId)
        {
            var review =_reviewRepository.GetReviewsFromAlbunId(albunId);
            return _mapper.Map<List<ReviewDto>>(review);
        }

        public OperationResult UpdateReview(int reviewId ,ReviewDto reviewdto)
        {
            var existsReview = _reviewRepository.GetReviewById(reviewId);
            if (existsReview == null)
            {
               return _operationResultService.CreateFailureResult("Review not found");
            }
            existsReview.AlbunId = reviewdto.AlbunId;
            existsReview.SubscriberId = existsReview.SubscriberId;
            existsReview.SubcriberUserName = reviewdto.SubcriberUserName;
            existsReview.Description = reviewdto.Description;
            existsReview.Score = reviewdto.Score;
            existsReview.CreationDate = reviewdto.CreationDate;

            _reviewRepository.UpdateReview(existsReview);
            return _operationResultService.CreateSuccessResult("Review Updated");
        }
    }
}
