using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Threading
{
    class Program
    {

        static int factorial(int number)
        {
            if (number.Equals(0))
                return 1;
            return number*factorial(number - 1);
        }
        static int factorialFor(int number)
        {
            if (number.Equals(0))
                return 1;
            int factorial=1;
            for (var i = number; i > 0; i--)
            {
                factorial = factorial *i ;
            }
            return factorial;
        }

        static void EvenNumbers()
        {
            double sum = 0;
            for (int i = 0; i < 50000000; i++)
            {
                if (i % 2 == 0)
                {
                    sum =sum+ i;
                }
            }
            Console.WriteLine("sum of even numbers = " + sum);
        }
        static void OddNumbers()
        {
            double sum = 0;
            for (int i = 0; i < 50000000; i++)
            {
                if (i % 2 == 1)
                {
                    sum = sum + i;
                }
            }
            Console.WriteLine("sum of odd numbers = " + sum);
        }

        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();
          
            //watch.Stop();
            //Console.Write(watch.ElapsedMilliseconds);
            //Console.ReadLine();
            //watch = Stopwatch.StartNew();
            EvenNumbers();
            OddNumbers();
            watch.Stop();
            Console.WriteLine("Single threading"+watch.ElapsedMilliseconds+ "ms");
            Console.ReadLine();
            watch = Stopwatch.StartNew();
            Thread t1 = new Thread(EvenNumbers);
            Thread t2 = new Thread(OddNumbers);
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            watch.Stop();
            Console.WriteLine("Multiple threading"+watch.ElapsedMilliseconds + "ms");
            Console.ReadLine();

        }
    }
}
