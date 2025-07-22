using GrapghQL_Altair_CoreWebApp.Data.Models;

namespace GrapghQL_Altair_CoreWebApp.Data.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly List<Review> _reviewsRepository = new List<Review>();

        public ReviewRepository()
        {
            // Initialize with some sample data
            _reviewsRepository.Add(new Review
            {
                Id = 1,
                Rating = 7,
                Comment = "Good course.",
                CourseId = 1
            });
            _reviewsRepository.Add(new Review
            {
                Id = 2,
                Rating = 9,
                Comment = "Very good.",
                CourseId = 1
            });
            _reviewsRepository.Add(new Review
            {
                Id = 5,
                Rating = 6,
                Comment = "Not bad.",
                CourseId = 1
            });
            _reviewsRepository.Add(new Review
            {
                Id = 3,
                Rating = 8,
                Comment = "Good.",
                CourseId = 2
            });
            _reviewsRepository.Add(new Review
            {
                Id = 4,
                Rating = 10,
                Comment = "Excellent course.",
                CourseId = 2
            });
        }

        public List<Review> GetAllReviews()
        {
            return _reviewsRepository;
        }

        public bool IsReviewExists(int reviewId)
        {
            return _reviewsRepository.Any(r => r.Id == reviewId);
        }

        public Review GetReviewById(int reviewId)
        {
            return _reviewsRepository.Find(c => c.Id == reviewId);
        }

        public List<Review> GetReviewsOfTheCourse(int courseId)
        {
            return _reviewsRepository.Where(c => c.CourseId == courseId).ToList();
        }

        public Review AddReview(Review review)
        {
            if (review is not null)
            {
                review.Id = _reviewsRepository.Count + 1;
                _reviewsRepository.Add(review);
                return review;
            }

            return review;
        }

        public Review UpdateReview(int reviewId, Review review)
        {
            Review? updateReview = _reviewsRepository.Find(c => c.Id == reviewId);
            if (updateReview is not null && review is not null)
            {
                updateReview.Rating = review.Rating;
                updateReview.Comment = review.Comment;
                updateReview.CourseId = review.CourseId;
                return updateReview;
            }

            return updateReview;
        }

        public bool DeleteReview(int reviewId)
        {
            var review = _reviewsRepository.Find(c => c.Id == reviewId);
            if (review is not null) _reviewsRepository.Remove(review);

            return true;
        }
    }
}
