using AutoMapper;
using courses.DataTransferObjects.Requests;
using courses.DataTransferObjects.Responses;
using courses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courses.Business.Mapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Course, CourseSummaryResponse>();
            CreateMap<Course, CourseDetailResponse>();
            CreateMap<AddCourseRequest, Course>();
            CreateMap<UpdateCourseRequest, Course>();

        }
    }
}
