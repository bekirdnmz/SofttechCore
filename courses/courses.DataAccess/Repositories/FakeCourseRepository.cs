using courses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courses.DataAccess.Repositories
{
    public class FakeCourseRepository : ICourseRepository
    {
        private List<Course> courses;
        public FakeCourseRepository()
        {
            courses = new List<Course>()
            {
                new Course{ Id= 1, Name = "C#", Description = "C# is a programming language"},
                new Course{ Id= 2, Name = "Java", Description = "Java is a programming language"},
                new Course{ Id= 3, Name = "Python", Description = "Python is a programming language"},
                new Course{ Id= 4, Name = "C++", Description = "C++ is a programming language"},
                new Course{ Id= 5, Name = "JavaScript", Description = "JavaScript is a programming language"},
                new Course{ Id= 6, Name = "PHP", Description = "PHP is a programming language"},
                new Course{ Id= 7, Name = "Ruby", Description = "Ruby is a programming language"},
                new Course{ Id= 8, Name = "Swift", Description = "Swift is a programming language"},
                new Course{ Id= 9, Name = "Objective-C", Description = "Objective-C is a programming language"},
                new Course{ Id= 10, Name = "C", Description = "C is a programming language"},
            };
        }
        public ICollection<Course> GetAll()
        {
            return courses;
        }

        public IEnumerable<Course> SearchByName(string name)
        {
            return courses.Where(c => c.Name.ToLower().Contains(name.ToLower()));
        }
    }
}
