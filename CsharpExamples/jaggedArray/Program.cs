using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaggedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] jaggedArray = new string[3][];
            jaggedArray[0] = new string[3];
            jaggedArray[1] = new string[2];
            jaggedArray[2] = new string[1];

            jaggedArray[0][0] = "Bachelor";
            jaggedArray[0][1] = "Master";
            jaggedArray[0][2] = "Doctor";

            jaggedArray[1][0] = "Master";
            jaggedArray[1][1] = "Doctor";


            jaggedArray[2][0] = "Doctor";



            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.WriteLine(jaggedArray[i][j]);

                }
                Console.WriteLine("------------------------");
            }
            Console.ReadLine();
        }
    }
}
