using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cpr_validator
{
    class CPR
    {
        int[] control = new[] {4,3,2,7,6,5,4,3,2,1};
        int result;
        public bool validate(int[] cpr)
        {
            for (int i = 0; i < control.Length; i++)
            {
                result=result+ control[i] * cpr[i];
            }
            //int cprnumber;
            //Int32.TryParse(string.Join("",cpr),out cprnumber);
            //int controlnumber;
            //Int32.TryParse(string.Join("", result), out controlnumber);
            return result % 11 == 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cpr");
            string cprnumber = Console.ReadLine();
            int[]c=new int[10];
            var test = cprnumber.ToCharArray();
            CPR cpr = new CPR();
            int[] o = new int[] {2,0,1,2,8,5,3,0,0,1 };
           
        }
    }
}
