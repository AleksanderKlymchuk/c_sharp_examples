using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication2
{

    class FileAccess
    {
        private string read(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File does not exist");
            }
            else
            {
                try
                {
                    return File.ReadAllText(path);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                
            }
            
           
        }
        private void write(string path,string content)
        {
            try
            {
                File.WriteAllText(path,content);
            }
            catch
            {
                throw;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            newEmp emp = new newEmp();
        }
    }


    abstract class baseEmp
    {
        public baseEmp()
        {
            print();
        }
        public abstract void print();
    
    }
     class newEmp:baseEmp
     {
         public override void print()
         {
             Func<int, string> res = t => (t * 2).ToString();
             Console.WriteLine(res(2));
             Console.ReadLine();
         }
     }

 
}
