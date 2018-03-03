using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesEF.Interfaces
{
    interface IRepository<T>
    {
        void Add(T item);

        void Remove(int id);

        List<T> GetAll();

        T GetById(int id);

        void Update(T item);

        int Count();
    }
}
