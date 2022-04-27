using courses.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace courses.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var courses = courseService.GetCourses();
            return Ok(courses);
        }
    }
}
