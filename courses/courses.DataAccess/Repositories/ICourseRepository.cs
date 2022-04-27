using courses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courses.DataAccess.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> SearchByName(string name);

    }
}
