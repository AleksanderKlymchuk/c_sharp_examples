using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleInheritance
{
    interface Icar
    {
        void getCarInfo();
    }
    interface Ibyke
    {
        void getBykeInfo();
    }
    class car:Icar
    {
        public void getCarInfo()
        {
            Console.WriteLine("car");
            Console.ReadLine();
        }
    }
    class byke:Ibyke
    {
        public void getBykeInfo()
        {
            Console.WriteLine("byke");
            Console.ReadLine();
        }
    }
    class transport : Ibyke, Icar
    {
        byke b = new byke();
        car c = new car();
      public void getBykeInfo(){
           b.getBykeInfo();   
        }
      public void getCarInfo()
       {
           c.getCarInfo();
       }
    }
    class Program
    {
        static void Main(string[] args)
        {
            transport tr = new transport();
            tr.getBykeInfo();
            tr.getCarInfo();
        }
    }
}
