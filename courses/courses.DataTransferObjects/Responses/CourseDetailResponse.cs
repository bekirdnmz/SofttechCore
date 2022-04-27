using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courses.DataTransferObjects.Responses
{
    public class CourseDetailResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? Price { get; set; }
        public int? TotalHours { get; set; }
        public int CategoryId { get; set; }
        public string CourseImage { get; set; } = "https://loremflickr.com/320/180";

        public string CategoryName { get; set; }
        public int TotalStutentsCount { get; set; } = 20;
        
    }
}
