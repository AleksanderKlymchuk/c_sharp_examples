using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi
{
    public interface IDataService
    {
        Task<IEnumerable<Employee>> Get(int Id);
        Task<IEnumerable<Employee>> Get();
        Task<IEnumerable<Employee>> GetAllAsync();
        IEnumerable<Employee> GetAllSync();
        void Add(Employee obj);
        void Update(Employee obj, int Id);
        void Delete(int id);
        IEnumerable<User> GetUserList();
    }
}
