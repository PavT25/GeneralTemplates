using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GrapghQL_Altair_CoreWebApp.Data.Models;
using GrapghQL_Altair_CoreWebApp.Data.Repositories;

namespace GrapghQL_Altair_CoreWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesRepository _courseRepository;
        private readonly IReviewRepository _reviewRepository;

        public CoursesController(ICoursesRepository courseRepository, IReviewRepository reviewRepository)
        {
            _courseRepository = courseRepository;
            _reviewRepository = reviewRepository;
        }

        [HttpGet(Name = "GetAll")]
        public IActionResult GetAll()
        {
            List<Course> allCources = _courseRepository.GetAllCourses();
            return Ok(allCources);
        }

        [HttpGet("{id}")]
        public IActionResult GetCourseById(int id)
        {
            if (!_courseRepository.IsCourseExists(id))
            {
                return NotFound($"Get course by ID. Course with ID {id} does not exist.");
            }

            Course course = _courseRepository.GetCourseById(id);
            return Ok(course);
        }

        [HttpPost(Name = "AddCourse")]
        public IActionResult AddCourse([FromBody] Course course)
        {
            var courseAdded = _courseRepository.AddCourse(course);

            if (courseAdded is not null)
            {
                return Ok(course);
            }
            return BadRequest("Add course. The course could not be added.");
        }

        [HttpPost("{courseId}/reviews", Name = "AddReview")]
        public IActionResult AddReview(int courseId, [FromBody] Review review)
        {
            if (!_courseRepository.IsCourseExists(courseId))
            {
                return NotFound($"Add review. Course with ID {courseId} does not exist.");
            }

            review.CourseId = courseId;
            _reviewRepository.AddReview(review);
            bool courseUpdated = _courseRepository.UpdateReviewsOfTheCourse(courseId);

            if (courseUpdated)
            {
                return (CreatedResult)Created("Add review. The review was added.", review);
            }
            return BadRequest($"Add review. The review could not be added to the course with ID {courseId}.");
        }

        [HttpPut]
        public IActionResult Update(int id, [FromBody] Course course)
        {
            if (!_courseRepository.IsCourseExists(id))
            {
                return NotFound($"Update course. Course with ID {id} does not exist.");
            }

            var courseUpdated = _courseRepository.UpdateCourse(id, course);

            if (courseUpdated is not null)
            {
                return Ok(courseUpdated);
            }
            return BadRequest($"Update course. The course with ID {id} could not be updated.");
        }

        [HttpPut("{courseId}/reviews/{reviewId}")]
        public IActionResult UpdateReview(int courseId, int reviewId, [FromBody] Review review)
        {
            if (!_courseRepository.IsCourseExists(courseId))
            {
                return NotFound($"Update review. Update review. Course with ID {courseId} does not exist.");
            }
            if (!_reviewRepository.IsReviewExists(reviewId))
            {
                return NotFound($"Update review. Review with ID {reviewId} does not exist.");
            }
            if (!_courseRepository.IsReviewOfTheCourseExists(courseId, reviewId))
            {
                return BadRequest($"Update review. Review with ID {reviewId} does not belong to course with ID {courseId}.");
            }

            review.CourseId = courseId;
            var reviewUpdated = _reviewRepository.UpdateReview(reviewId, review);

            if (reviewUpdated is not null)
            {
                return Ok(reviewUpdated);
            }
            return BadRequest($"Update review. The review with ID {reviewId} could not be updated.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_courseRepository.IsCourseExists(id))
            {
                return NotFound($"Delete course. Course with ID {id} does not exist.");
            }

            bool courseDeleted = _courseRepository.DeleteCourse(id);

            if (courseDeleted)
            {
                return Ok(courseDeleted);
            }
            return BadRequest($"Delete course. The course with ID {id} could not be deleted.");
        }

        [HttpDelete("{courseId}/reviews/{reviewId}")]
        public IActionResult DeleteReview(int courseId, int reviewId)
        {
            if (!_courseRepository.IsCourseExists(courseId))
            {
                return NotFound($"Delete review. Course with ID {courseId} does not exist.");
            }

            if (!_reviewRepository.IsReviewExists(reviewId))
            {
                return NotFound($"Delete review. Review with ID {reviewId} does not exist.");
            }

            if (!_courseRepository.IsReviewOfTheCourseExists(courseId, reviewId))
            {
                return BadRequest($"Delete review. Review with ID {reviewId} does not belong to course with ID {courseId}.");
            }

            // Proceed to delete the review and update the course
            bool reviewDeleted = _reviewRepository.DeleteReview(reviewId);
            bool courseUpdated = _courseRepository.UpdateReviewsOfTheCourse(courseId);

            if (reviewDeleted && courseUpdated)
            {
                return Ok(reviewDeleted && courseUpdated);
            }
            return BadRequest($"Delete review. The review with ID {reviewId} could not be deleted.");
        }
    }
}
