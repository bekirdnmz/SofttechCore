using courses.Business;
using courses.DataTransferObjects.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace courses.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService courseService;
        private readonly ILogger<CoursesController> logger;

        public CoursesController(ICourseService courseService, ILogger<CoursesController> logger)
        {
            this.courseService = courseService;
            this.logger = logger; 
        }
       

        [HttpGet]
        public IActionResult Get()
        {
            var courses = courseService.GetCourses();
            var message = $"{DateTime.Now} tarihinde, get request metodu çalıştı";
            logger.LogInformation(message);
            return Ok(courses);
        }
       
        [HttpGet("[action]/{name}")]
        public IActionResult Search(string name)
        {
            var courses = courseService.SearchCourse(name);
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var course = courseService.GetCourse(id);
            return Ok(course);
            
        }

        [HttpPost]
        public IActionResult Post(AddCourseRequest course)
        {
            if (ModelState.IsValid)
            {
                int id = courseService.CreateCourse(course);
                return CreatedAtAction("Get", new { id = id },null);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateCourseRequest course)
        {
            if (courseService.CourseExists(id))
            {
                if (ModelState.IsValid)
                {
                    courseService.UpdateCourse(id, course);
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            return NotFound();

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (courseService.CourseExists(id))
            {
                courseService.DeleteCourse(id);
                return Ok();
            }
            return NotFound();
        }


    }
}
