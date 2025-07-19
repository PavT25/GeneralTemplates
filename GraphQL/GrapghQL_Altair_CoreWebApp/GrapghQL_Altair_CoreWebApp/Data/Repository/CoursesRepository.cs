using GrapghQL_Altair_CoreWebApp.Data.Models;

namespace GrapghQL_Altair_CoreWebApp.Data.Repositories
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly List<Course> _repository = new List<Course>();

        public CoursesRepository()
        {
            // Seed data
            _repository.Add(new Course
            {
                Id = 1,
                Name = "Introduction to GraphQL",
                Description = "Learn the basics of GraphQL.",
                Review = 2,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            });
            _repository.Add(new Course
            {
                Id = 2,
                Name = "Advanced GraphQL Techniques",
                Description = "Deep dive into advanced GraphQL features.",
                Review = 3,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            });
        }

        public List<Course> GetAllCourses()
        {
            return _repository;
        }

        public Course GetCourseById(int id)
        {
            return _repository.Find(c => c.Id == id);
        }

        public Course AddCourse(Course course)
        {
            if (course is not null)
            {
                course.Id = _repository.Count + 1;
                course.DateCreated = DateTime.Now;
                course.DateUpdated = DateTime.Now;
                _repository.Add(course);
            }

            return course;
        }

        public Course UpdateCourse(int id, Course course)
        {
            var _course = _repository.Find(c => c.Id == id);
            if (_course is not null)
            {
                _course.Name = course.Name;
                _course.Description = course.Description;
                _course.Review = course.Review;
                _course.DateUpdated = DateTime.Now;
            }

            return course;
        }

        public bool DeleteCourse(int id)
        {
            var _course = _repository.Find(c => c.Id == id);
            if (_course is not null) _repository.Remove(_course);

            return true;
        }
    }
}
