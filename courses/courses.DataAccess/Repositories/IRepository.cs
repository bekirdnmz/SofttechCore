using courses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courses.DataAccess.Repositories
{
    public interface IRepository<T> where T:class, IEntity,new()
    {
        ICollection<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        bool IsExist(int id);


    }
}
