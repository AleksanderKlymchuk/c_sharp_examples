using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive
{
    class Program
    {

        public static double Factorial(int number)
        {
            if (number == 0)
                return 1;
            return number * Factorial(number - 1);

        }
        public static void FindFiles(string path)
        {
            foreach(string name in Directory.GetFiles(path)){
                Console.WriteLine(name);
            }
            foreach (string directory in Directory.GetDirectories(path))
            {
                FindFiles(directory);
            }
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Please enter a number");
            //int number = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine(Factorial(number));
            //Console.ReadLine();
            //string path = Directory.GetCurrentDirectory();
            //string rootPath="C:\\Users\\oleksandr\\documents\\visual studio 2013\\Projects\\CsharpExamples\\Recursive\\Year";
            //FindFiles(rootPath);
            //Console.ReadLine();

            string s = "ABCD";
            string ns="";
            int le = s.Length;
            for (int i=s.Length; i>0; i--)
            {
                ns += s[i-1];
            }
            s="";
            for (int i = 0; i < ns.Length; i++)
            {
                s +=ns[ ns.Length - i-1];
            }
            var arr = s.ToCharArray();
            Array.Reverse(arr);

            Console.WriteLine(new String(arr));
            Console.ReadLine();

        }
    }
}
