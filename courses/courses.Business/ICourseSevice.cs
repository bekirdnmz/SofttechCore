using courses.DataTransferObjects.Responses;
using courses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courses.Business
{
    public interface ICourseService
    {
        IEnumerable<CourseSummaryResponse> GetCourses();
    }
}
