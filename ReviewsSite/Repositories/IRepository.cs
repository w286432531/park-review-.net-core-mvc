using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsSite.Repositories
{
    public interface IRepository<T>
    {
        void Create(T obj);
        IEnumerable<T> GetAll();

        T GetByID(int id);

        void Update(T obj);

        void Delete(T obj);
    }
}
