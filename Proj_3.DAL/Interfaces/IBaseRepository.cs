using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_3.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        bool Create(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
        //bool Update(T entity);
        bool Delete(int id);
    }
}
