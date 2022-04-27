using courses.DataTransferObjects.Responses;
using courses.Entities;

namespace courses.Web.Models
{
    public class CourseListViewModel
    {
        public IEnumerable<CourseSummaryResponse> Courses { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
