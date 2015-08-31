using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi
{
    public interface IData<T>
    {
        IEnumerable<T> GetAll();
        T Get(int Id);
        void Add(T obj);
        void Update(T obj, int Id);
        void Delete(int id);
    }
}
