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
            // Check if the course exists
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
            bool courseAdded = _courseRepository.AddCourse(course);

            if (courseAdded)
            {
                return (CreatedResult)Created("Add course. The course was created", course);
            }
            return BadRequest("Add course. The course could not be added.");
        }

        [HttpPost("{courseId}/reviews", Name = "AddReview")]
        public IActionResult AddReview(int courseId, [FromBody] Review review)
        {
            // Check if the course exists
            if (!_courseRepository.IsCourseExists(courseId))
            {
                return NotFound($"Add review. Course with ID {courseId} does not exist.");
            }

            review.CourseId = courseId;
            bool reviewAdded = _reviewRepository.AddReview(review);
            bool courseUpdated = _courseRepository.UpdateReviewsOfTheCourse(courseId);

            if (reviewAdded && courseUpdated)
            {
                return (CreatedResult)Created("Add review. The review was added.", courseId);
            }
            return BadRequest($"Add review. The review could not be added to the course with ID {courseId}.");
        }

        [HttpPut]
        public IActionResult Update(int id, [FromBody] Course course)
        {
            // Check if the course exists
            if (!_courseRepository.IsCourseExists(id))
            {
                return NotFound($"Update course. Course with ID {id} does not exist.");
            }

            bool courseUpdated = _courseRepository.UpdateCourse(id, course);

            if (courseUpdated)
            {
                return Ok(courseUpdated);
            }
            return BadRequest($"Update course. The course with ID {id} could not be updated.");
        }

        [HttpPut("{courseId}/reviews/{reviewId}")]
        public IActionResult UpdateReview(int courseId, int reviewId, [FromBody] Review review)
        {
            // Check if the course exists
            if (!_courseRepository.IsCourseExists(courseId))
            {
                return NotFound($"Update review. Update review. Course with ID {courseId} does not exist.");
            }
            // Check if the review exists
            if (!_reviewRepository.IsReviewExists(reviewId))
            {
                return NotFound($"Update review. Review with ID {reviewId} does not exist.");
            }
            // Check if the review belongs to the course
            if (!_courseRepository.IsReviewOfTheCourseExists(courseId, reviewId))
            {
                return BadRequest($"Update review. Review with ID {reviewId} does not belong to course with ID {courseId}.");
            }

            review.CourseId = courseId;
            bool reviewUpdated = _reviewRepository.UpdateReview(reviewId, review);

            if (reviewUpdated)
            {
                return Ok(reviewUpdated);
            }
            return BadRequest($"Update review. The review with ID {reviewId} could not be updated.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Check if the course exists
            if (!_courseRepository.IsCourseExists(id))
            {
                return NotFound($"Delete course. Course with ID {id} does not exist.");
            }

            // Proceed to delete the course
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
            // Check if the course exists
            if (!_courseRepository.IsCourseExists(courseId))
            {
                return NotFound($"Delete review. Course with ID {courseId} does not exist.");
            }

            // Check if the review exists
            if (!_reviewRepository.IsReviewExists(reviewId))
            {
                return NotFound($"Delete review. Review with ID {reviewId} does not exist.");
            }

            // Check if the review belongs to the course
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
