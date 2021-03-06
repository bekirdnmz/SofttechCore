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
    public interface ICourseService
    {
        IEnumerable<CourseSummaryResponse> GetCourses();
        IEnumerable<CourseSummaryResponse> SearchCourse(string name);

        CourseDetailResponse GetCourse(int id);
        int CreateCourse(AddCourseRequest course);
        void UpdateCourse(int id, UpdateCourseRequest course);
        void DeleteCourse(int id);
        bool CourseExists(int id);
    }
}
