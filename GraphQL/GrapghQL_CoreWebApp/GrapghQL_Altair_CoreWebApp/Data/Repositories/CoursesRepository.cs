﻿using GrapghQL_Altair_CoreWebApp.Data.Models;

namespace GrapghQL_Altair_CoreWebApp.Data.Repositories
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly List<Course> _coursesRepository = new List<Course>();
        private readonly IReviewRepository _reviewsRepository;

        public CoursesRepository(IReviewRepository reviewsRepository)
        {
            _reviewsRepository = reviewsRepository;

            // Initialize with some sample data
            _coursesRepository.Add(new Course
            {
                Id = 1,
                Name = "Introduction to GraphQL",
                Description = "Learn the basics of GraphQL.",
                Reviews = new List<Review>(),
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            });
            _coursesRepository.Add(new Course
            {
                Id = 2,
                Name = "Advanced GraphQL Techniques",
                Description = "Deep dive into advanced GraphQL features.",
                Reviews = new List<Review>(),
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            });

            foreach (Course course in _coursesRepository)
            {
                var reviewsForCourse = _reviewsRepository.GetReviewsOfTheCourse(course.Id);
                course.Reviews = reviewsForCourse;
            }
        }

        public List<Course> GetAllCourses()
        {
            return _coursesRepository;
        }

        public bool IsCourseExists(int courseId)
        {
            return _coursesRepository.Any(c => c.Id == courseId);
        }

        public Course GetCourseById(int courseId)
        {
            return _coursesRepository.Find(c => c.Id == courseId);
        }

        public Course AddCourse(Course course)
        {
            if (course is not null)
            {
                Course newCourse = new Course
                {
                    Id = _coursesRepository.Count + 1,
                    Name = course.Name,
                    Description = course.Description,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    Reviews = course.Reviews ?? new List<Review>(),
                };
                _coursesRepository.Add(newCourse);

                if (course.Reviews is not null)
                {
                    foreach (Review review in course.Reviews)
                    {
                        Review newReview = new Review
                        {
                            Id = _reviewsRepository.GetAllReviews().Count + 1,
                            Rating = review.Rating,
                            Comment = review.Comment,
                            CourseId = newCourse.Id
                        };
                        _reviewsRepository.AddReview(newReview);
                    }
                }
                return newCourse;
            }

            return course;
        }

        public bool IsReviewOfTheCourseExists(int courseId, int reviewId)
        {
            var course = _coursesRepository.Find(c => c.Id == courseId);
            if (course is not null)
            {
                return course.Reviews.Any(r => r.Id == reviewId);
            }
            return false;
        }

        public Course UpdateCourse(int courseId, Course course)
        {
            var _course = _coursesRepository.Find(c => c.Id == courseId);
            if (_course is not null)
            {
                _course.Name = course.Name;
                _course.Description = course.Description;
                _course.DateUpdated = DateTime.Now;

                // Update reviews if provided
                if (course.Reviews is not null && course.Reviews.Count > 0)
                {
                    _course.Reviews = course.Reviews;
                }
            }

            return _course;
        }

        public bool UpdateReviewsOfTheCourse(int courseId)
        {
            var course = _coursesRepository.Find(c => c.Id == courseId);
            if (course is not null)
            {
                // Update the reviews for the course
                var reviewsForCourse = _reviewsRepository.GetReviewsOfTheCourse(courseId);
                course.Reviews = reviewsForCourse;
                return true;
            }
            return false;
        }

        public bool DeleteCourse(int courseId)
        {
            var _reviewsToDelete = _reviewsRepository.GetReviewsOfTheCourse(courseId);
            foreach (var review in _reviewsToDelete)
            {
                _reviewsRepository.DeleteReview(review.Id);
            }
            var _course = _coursesRepository.Find(c => c.Id == courseId);
            if (_course is not null) _coursesRepository.Remove(_course);

            return true;
        }
    }
}
