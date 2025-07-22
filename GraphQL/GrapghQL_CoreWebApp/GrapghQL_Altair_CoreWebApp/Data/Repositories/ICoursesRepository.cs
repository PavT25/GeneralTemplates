using GrapghQL_Altair_CoreWebApp.Data.Models;

namespace GrapghQL_Altair_CoreWebApp.Data.Repositories
{
    public interface ICoursesRepository
    {
        List<Course> GetAllCourses();
        bool IsCourseExists(int courseId);
        Course GetCourseById(int courseId);
        Course AddCourse(Course course);
        bool IsReviewOfTheCourseExists(int courseId, int reviewId);
        Course UpdateCourse(int courseId, Course course);
        bool UpdateReviewsOfTheCourse(int courseId);
        bool DeleteCourse(int courseId);
    }
}
