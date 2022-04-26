using courses.DataAccess.Repositories;
using courses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courses.Business
{
    public class CourseService : ICourseService
    {
        private ICourseRepository courseRepository;
        public CourseService(ICourseRepository repository)
        {
            courseRepository=repository;
        }
        public IEnumerable<Course> GetCourses()
        {
            return courseRepository.GetAll();
        }
    }
}
