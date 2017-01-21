using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvensTest
{
    class EvensPrintTest
    {
        static public void GetEvens(int maxVal, int startVal = 1)
        {
            if (startVal > maxVal)
            {
                int temp = maxVal;
                maxVal = startVal;
                startVal = maxVal;
            }
            for (int i = startVal; i <= maxVal; i++)
            {
                if (i % 2 == 0)
                    Console.WriteLine("Even: {0}", i);
            }
        }

        static void Main(string[] args)
        {
            try
            {
                int maxValue = 20;
                if (args.Length >= 1)
                {
                    if (args[0].ToUpper().Contains("HELP") || args[0].ToUpper().Contains("?"))
                    {
                        Console.WriteLine("Usage:");
                        Console.WriteLine("\t{0} [max value] [start value]", System.AppDomain.CurrentDomain.FriendlyName);
                        return;
                    }
                    maxValue = Convert.ToInt32(args[0]);
                }
                int startValue = 1;
                if (args.Length >= 2)
                {
                    startValue = Convert.ToInt32(args[1]);
                }
                GetEvens(maxValue, startValue);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Exception [{0}]", e.GetType());
            }
        }
    }
}
