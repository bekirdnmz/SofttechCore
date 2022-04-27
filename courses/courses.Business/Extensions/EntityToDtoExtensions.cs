using AutoMapper;
using courses.DataTransferObjects.Responses;
using courses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courses.Business.Extensions
{
    public static  class EntityToDtoExtensions
    {
        public static T ConvertToDto<T>(this ICollection<Course> courses, IMapper mapper) 
        {
            return mapper.Map<T>(courses);

        }

        public static T ConvertToDto<T>(this Course course, IMapper mapper)
        {
            return mapper.Map<T>(course);

        }

        public static IEnumerable<CourseSummaryResponse>  ConvertToCourseSummaryResponses(this ICollection<Course> courses, IMapper mapper)
        {
            return mapper.Map<IEnumerable<CourseSummaryResponse>>(courses); 
        } 
    }
}
