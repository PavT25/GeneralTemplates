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
        public CoursesController(ICoursesRepository courseRepository)
        {
            _courseRepository = courseRepository;
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
            Course course = _courseRepository.GetCourseById(id);
            return Ok(course);
        }

        [HttpPost(Name = "AddCourse")]
        public IActionResult AddCourse([FromBody]Course course)
        {
            Course addedCourse = _courseRepository.AddCourse(course);
            return Ok(addedCourse);
        }

        [HttpPut]
        public IActionResult Update(int id, [FromBody] Course course)
        {
            Course updatedCourse = _courseRepository.UpdateCourse(id, course);
            return Ok(updatedCourse);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _courseRepository.DeleteCourse(id);
            return Ok();
        }
    }
}
