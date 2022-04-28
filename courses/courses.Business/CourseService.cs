using AutoMapper;
using courses.Business.Extensions;
using courses.DataAccess.Repositories;
using courses.DataTransferObjects.Requests;
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

        public int CreateCourse(AddCourseRequest request)
        {
            var course = mapper.Map<Course>(request);
            courseRepository.Add(course);
            return course.Id;
        }

        public void DeleteCourse(int id)
        {
            courseRepository.Delete(id);
        }

        public CourseDetailResponse GetCourse(int id)
        {
            var course = courseRepository.Get(id);
            var dto = course.ConvertToDto<CourseDetailResponse>(mapper);
            return dto;
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

        public IEnumerable<CourseSummaryResponse> SearchCourse(string name)
        {
            var courses = (ICollection<Course>) courseRepository.SearchByName(name);
            var response = courses?.ConvertToDto<IEnumerable<CourseSummaryResponse>>(mapper);
            return response;

        }

        public void UpdateCourse(int id, UpdateCourseRequest request)
        {
            var course = mapper.Map<Course>(request);
            courseRepository.Update(course);
            
        }
    }
}
