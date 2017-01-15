using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class ConsoleApp2
    {
        // static void dumpVar<T>(T inval) where T : struct
        static void dumpVar<T>(T inval)
        {
            var min_field = inval.GetType().GetField("MinValue");
            var max_field = inval.GetType().GetField("MaxValue");
            if (min_field != null && max_field != null)
            {
                Console.WriteLine("{0} = {2} <= {1} <= {3}", typeof(T).FullName, inval, (T)min_field.GetValue(min_field), (T)max_field.GetValue(min_field));
            }
            else 
            {
                Console.WriteLine("{0} = {1}", typeof(T).FullName, inval);
            }
        }

        static void Main(string[] args)
        {
            dumpVar(42);
            dumpVar(3.14159);
            dumpVar(42L);
            dumpVar(true);
            dumpVar(1.0M);
            dumpVar("fooooom");
            Console.Write("Press any key");
            Console.ReadKey();
        }
    }
}
