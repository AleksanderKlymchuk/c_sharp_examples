using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameters
{
    class Program
    {

        static string display(ref int input)
        {
            input = input + 1;
            return ("You entered "+input.ToString());
        }
        static string displayout(out int input)
        {
            input = 2;
            return ("You entered " + input.ToString());
        }

        static void Main(string[] args)
        {
            int s = 2;
            int u;
            Console.WriteLine(display(ref s));
            Console.WriteLine(displayout(out u));

        }
    }
}
