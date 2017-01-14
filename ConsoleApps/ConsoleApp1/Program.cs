using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nahhhh");
            Console.WriteLine("Got {0} arguments", args.Length);

            int counter = 1;    // display counter not array index
            foreach (String a in args)
            {
                Console.WriteLine("Arg [{0}/{1}]: {2:s}", counter++, args.Length, a);
            }
            Console.ReadKey();
        }
    }
}
