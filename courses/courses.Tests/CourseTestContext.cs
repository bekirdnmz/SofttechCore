using courses.DataAccess.Data;
using courses.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courses.Tests
{
    public class CourseTestContext : CourseDbContext
    {
        public CourseTestContext(DbContextOptions<CourseDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO 1: Json verisi burada seed edilecek.
            seedData<Course>(modelBuilder, "../../../data/courses.json");
            base.OnModelCreating(modelBuilder);
        }

        private void seedData<T>(ModelBuilder modelBuilder, string file) where T : class      
        {
            using (StreamReader reader = new StreamReader(file))
            {
                string json = reader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<List<T>>(json);
                modelBuilder.Entity<T>().HasData(data);
            }
          
        }

    }
}
