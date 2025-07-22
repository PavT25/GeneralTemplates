using GrapghQL_Altair_CoreWebApp.Data.Models;

namespace GrapghQL_Altair_CoreWebApp.Data.Repositories
{
    public interface IReviewRepository
    {
        List<Review> GetAllReviews();
        bool IsReviewExists(int reviewId);
        Review GetReviewById(int reviewId);
        List<Review> GetReviewsOfTheCourse(int courseId);
        bool AddReview(Review? review);
        bool UpdateReview(int reviewId, Review? review);
        bool DeleteReview(int reviewId);
    }
}
