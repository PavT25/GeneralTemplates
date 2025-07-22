using GrapghQL_Altair_CoreWebApp.Data.Models;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace GrapghQL_Altair_CoreWebApp.Data.Repositories
{
    public interface IReviewRepository
    {
        List<Review> GetAllReviews();
        bool IsReviewExists(int reviewId);
        Review GetReviewById(int reviewId);
        List<Review> GetReviewsOfTheCourse(int courseId);
        Review AddReview(Review review);
        Review UpdateReview(int reviewId, Review review);
        bool DeleteReview(int reviewId);
    }
}
