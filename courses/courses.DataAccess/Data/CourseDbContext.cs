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
        public CourseDbContext(DbContextOptions<CourseDbContext> contextOptions) : base(contextOptions)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
              new Category { Id = 1, Name = "Development" }
            , new Category { Id = 2, Name = "Art" },
              new Category { Id = 3, Name = "Languages" });

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = 1,
                    Name = "C# Basics",
                    Description = "Learn C# Basics",
                    CourseImage = "https://picsum.photos/200",
                    TotalHours = 50,
                    CategoryId = 1,
                },
                new Course
                {
                    Id = 2,
                    Name = "C# Advanced",
                    Description = "Learn C# Advanced",
                    CourseImage = "https://picsum.photos/200",
                    TotalHours = 80,
                    CategoryId = 1
                },
                new Course
                {
                    Id = 3,
                    Name = "Painting Course",
                    Description = "Painting with technics",
                    CourseImage = "https://picsum.photos/200",
                    TotalHours = 50,
                    CategoryId = 2
                },
                new Course
                {
                    Id = 4,
                    Name = "Spanish Course",
                    Description = "Learn Spanish",
                    CourseImage = "https://picsum.photos/200",
                    TotalHours = 50,
                    CategoryId = 3
                }
                );
        }
    }
}
