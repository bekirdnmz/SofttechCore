using courses.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courses.DataAccess.Data
{
    public class CourseDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }

        
    }
}
