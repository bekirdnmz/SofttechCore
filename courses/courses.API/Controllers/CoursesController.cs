using courses.Business;
using courses.DataTransferObjects.Requests;
using courses.DataTransferObjects.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Text;

namespace courses.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService courseService;
        private readonly ILogger<CoursesController> logger;
        private readonly IMemoryCache memoryCache;
        private readonly IDistributedCache distributedCache;

        public CoursesController(ICourseService courseService,
                                 ILogger<CoursesController> logger,
                                 IMemoryCache memoryCache,
                                 IDistributedCache distributedCache
                                 )
        {
            this.courseService = courseService;
            this.logger = logger;
            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;
        }


        [HttpGet]

        public IActionResult Get()
        {

            if (!memoryCache.TryGetValue("courseData", out IEnumerable<CourseSummaryResponse> courses))
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(1)).RegisterPostEvictionCallback((key, value, evictionReason, state) =>
                {
                    //bu option nesnesinin kullanılıdığı in-memory cache koleksiyonundan cache çıkarıldığında,
                    //bu delege metod devreye girecek.
                });

                memoryCache.Set("courseData", courseService.GetCourses(), cacheEntryOptions);
                courses = courseService.GetCourses();
            }


            // var courses = courseService.GetCourses();
            var message = $"{DateTime.Now} tarihinde, get request metodu çalıştı";
            logger.LogInformation(message);
            return Ok(new { courses = courses, cacheTime = DateTime.Now.ToString() });
        }

        public string CachedTime { get; set; }


        [HttpGet("[action]/{name}")]
        public IActionResult Search(string name)
        {
            var array = distributedCache.Get("cachedTime");
            if (array != null)
            {
                CachedTime = Encoding.UTF8.GetString(array);
            }


            IEnumerable<CourseSummaryResponse> actionResult;
            if (distributedCache.Get("searchCache") != null)
            {
                var searchArray = distributedCache.Get("searchCache");
                string result = Encoding.UTF8.GetString(searchArray);
                actionResult = JsonConvert.DeserializeObject<IEnumerable<CourseSummaryResponse>>(result);
            }
            else
            {
                actionResult = courseService.SearchCourse(name);
                var jsonSerialize = JsonConvert.SerializeObject(actionResult);
                distributedCache.Set("searchCache", Encoding.UTF8.GetBytes(jsonSerialize));
            }



            return Ok(actionResult);
        }

        [HttpGet("{id}")]
        //[ResponseCache(Duration = 60, VaryByQueryKeys = new[] { "id" })]
        public IActionResult Get(int id)
        {
            var course = courseService.GetCourse(id);
            return Ok(new { course = course, date = DateTime.Now.ToString()  });

        }

        

        [HttpPost]
        public IActionResult Post(AddCourseRequest course)
        {
            if (ModelState.IsValid)
            {
                int id = courseService.CreateCourse(course);
                return CreatedAtAction("Get", new { id = id }, null);
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
