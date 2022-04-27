﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courses.Entities
{
    public class Course :IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? Price { get; set; }
        public int? TotalHours { get; set; }
        public Category Category { get; set; }

        public string CourseImage { get; set; } = "https://loremflickr.com/320/180";

    }
}
