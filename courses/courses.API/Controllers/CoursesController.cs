﻿using courses.Business;
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
    }
}
