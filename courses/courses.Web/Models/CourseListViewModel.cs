using courses.Entities;

namespace courses.Web.Models
{
    public class CourseListViewModel
    {
        public IEnumerable<Course> Courses { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
