using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    abstract class EntityBase
    {
        public  EntityBase()
        {
            ID = Guid.NewGuid();
            Message();
        }
        private Guid _id;
        public Guid ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public abstract void Message();
       
    }
    class car:EntityBase
    {
        public car()
        {

        }
        public override void Message()
        {
            Console.WriteLine("Hello car");
            Console.ReadLine();
        }
      
    }
    class oil : EntityBase
    {
        public override void Message()
        {
            Console.WriteLine("Hello oil");
            Console.ReadLine();
        }

    }
   
    class Program
    {
        static void Main(string[] args)
        {
            car c = new car();
           
        }
    }
   

}
