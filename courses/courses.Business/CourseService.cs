using AutoMapper;
using courses.Business.Extensions;
using courses.DataAccess.Repositories;
using courses.DataTransferObjects.Responses;
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
        private IMapper mapper;

        public CourseService(ICourseRepository repository, IMapper mapper)
        {
            courseRepository = repository;
            this.mapper = mapper;
        }
        public IEnumerable<CourseSummaryResponse> GetCourses()
        {
            var courses = courseRepository.GetAll();
            var response = courses.ConvertToDto<IEnumerable<CourseSummaryResponse>>(mapper);
            // var result = courses.ConvertToCourseSummaryResponses(mapper);

            return response;

            //return courses.Select(c => new CourseSummaryResponse
            //{
            //    Id = c.Id,
            //    Name = c.Name,
            //    Description = c.Description,                          
            //    CourseImage= c.CourseImage
            //});




        }
    }
}
