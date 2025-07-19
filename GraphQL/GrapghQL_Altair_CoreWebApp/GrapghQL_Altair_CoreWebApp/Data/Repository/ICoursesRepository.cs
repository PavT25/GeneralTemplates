using GrapghQL_Altair_CoreWebApp.Data.Models;

namespace GrapghQL_Altair_CoreWebApp.Data.Repositories
{
    public interface ICoursesRepository
    {
        List<Course> GetAllCourses();
        Course GetCourseById(int id);
        Course AddCourse(Course course);
        Course UpdateCourse(int id, Course course);
        bool DeleteCourse(int id);
    }
}
