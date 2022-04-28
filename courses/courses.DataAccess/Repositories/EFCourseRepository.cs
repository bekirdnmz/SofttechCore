using courses.DataAccess.Data;
using courses.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courses.DataAccess.Repositories
{
    public class EFCourseRepository : ICourseRepository
    {
        private CourseDbContext courseDbContext;

        public EFCourseRepository(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public void Add(Course entity)
        {
            courseDbContext.Courses.Add(entity);
            courseDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var course = courseDbContext.Courses.Find(id);
            courseDbContext.Courses.Remove(course);
            courseDbContext.SaveChanges();
        }

        public Course Get(int id)
        {
            return courseDbContext.Courses.Include(c=>c.Category).FirstOrDefault (x=>x.Id==id);
        }

        public ICollection<Course> GetAll()
        {
            return courseDbContext.Courses.ToList();
        }

        public bool IsExist(int id)
        {
            return courseDbContext.Courses.Any(x => x.Id == id);
        }

        public IEnumerable<Course> SearchByName(string name)
        {
            return courseDbContext.Courses.Where(c => c.Name.Contains(name) || 
                                                      c.Description.Contains(name))
                                          .ToList();

            
        }

        public void Update(Course entity)
        {
            courseDbContext.Courses.Update(entity);
            courseDbContext.SaveChanges();
        }
    }
}
