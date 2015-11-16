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

            new Employee(){EmployeeId=1,EmployeeName="Oleksandr", ManagerId=2},
            new Employee(){EmployeeId=2,EmployeeName="Thomas", ManagerId=null},
            new Employee(){EmployeeId=3,EmployeeName="Rasmus", ManagerId=2},
            new Employee(){EmployeeId=4,EmployeeName="Niels", ManagerId=1}
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
            Employee emp = employees.Where(x => x.EmployeeId.Equals(Id)).FirstOrDefault();
            emp.EmployeeName = employee.EmployeeName;
            emp.ManagerId = employee.ManagerId;
        }
        public void Delete(int id)
        {
            employees.RemoveAll(x => x.EmployeeId.Equals(id));
        }
        public IEnumerable<User> GetUserList()
        {
            using (conn){
                conn.ConnectionString = dbconnection;
                conn.Open();
                var users=conn.Query<User,Employee,User>
                    ("RE_Repository_User_GetTree",
                    (us, em) => { em.UserId=us.UserId; return us; },
                    commandType:CommandType.StoredProcedure,
                    splitOn:"UserId,UserName,EmployeeId,EmployeeName"
                    );
                return users;
            }




        }
    }
}
