using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;


namespace WebApi
{

    public class EmployeeService:BaseDataService, IDataService
    {

        public EmployeeService()
        {
            this.conn = new SqlConnection();
        }

        List<Employee> employees = new List<Employee>(){

            new Employee(){Id=1,Name="Oleksandr", ManagerId=2},
            new Employee(){Id=2,Name="Thomas", ManagerId=null},
            new Employee(){Id=3,Name="Rasmus", ManagerId=2},
            new Employee(){Id=4,Name="Niels", ManagerId=1}
        };

        public async Task<IEnumerable<Employee>> Get(int Id)
        {
            using (conn)
            {
                conn.ConnectionString = dbconnection;
                await conn.OpenAsync();
                return await conn.QueryAsync<Employee>("select * from employee where id=@id",Id);
            } 
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            using (conn)
            {
                conn.ConnectionString = dbconnection;
                await conn.OpenAsync();
                return await conn.QueryAsync<Employee>("select * from employee");
            }
        }
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            using (conn)
            {
                conn.ConnectionString = dbconnection;
                await  conn.OpenAsync();
                return await conn.QueryAsync<Employee>("select * from employee");
            } 

        }
        public IEnumerable<Employee> GetAllSync()
        {
            using (conn)
            {
                conn.ConnectionString = dbconnection;
                conn.Open();
                return conn.Query<Employee>("select * from employee");
            }
        }

        public void Add(Employee employee)
        {
            employees.Add(employee);
        }
        public void Update(Employee employee, int Id)
        {
            Employee emp = employees.Where(x => x.Id.Equals(Id)).FirstOrDefault();
            emp.Name = employee.Name;
            emp.ManagerId = employee.ManagerId;
        }
        public void Delete(int id)
        {
            employees.RemoveAll(x => x.Id.Equals(id));
        }

    }
}
