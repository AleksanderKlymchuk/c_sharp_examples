using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{


    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ManagerId { get; set; }
    }

    delegate void DisplayMessage(string Message);
    delegate string GetMessage(string Message);

    class Program
    {
       static void Hello(string Message)
        {

            Console.WriteLine(Message);
            Console.ReadLine();
        }
      static string GoodBey(string Message) {

           return "GoodBey" + Message;
       }
        static List<Employee> employees = new List<Employee>(){

            new Employee(){Id=1,Name="Oleksandr", ManagerId=2},
            new Employee(){Id=2,Name="Thomas", ManagerId=null},
            new Employee(){Id=3,Name="Rasmus", ManagerId=2},
            new Employee(){Id=4,Name="Niels", ManagerId=1}
        };
        static bool findEmployee(Employee emp)
        {
            return emp.Id == 1;
        }
        static void Main(string[] args)
        {
            //Func<string, string> selector = str => str.ToUpper();

            //Func<int, string> test = t => (t * 2).ToString();

            //Predicate<Employee> premp = new Predicate<Employee>(findEmployee);
            //Employee employee = employees.Find(delegate(Employee x) { return x.Id == 2; });
            //Console.WriteLine(employee.Name);
            //Console.ReadLine();


            DisplayMessage dm = new DisplayMessage(Hello);
            dm("Hello delegate");
            GetMessage gm = new GetMessage(GoodBey);
            Console.WriteLine(gm(" delegate"));
            Console.ReadLine();

        }
    }
}
