using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasicsS5L42Exercises
{
    class Program
    {
        static string getIntString(string prompt, string exitStr)
        {
            while (true)
            {
                Console.Write(prompt.Length > 0 ? prompt : "Enter an integer: ");
                try
                {
                    string val = Console.ReadLine();
                    if (val.ToUpper() == exitStr.ToUpper())
                    {
                        return val;
                    }
                    Convert.ToInt32(val);
                    return val;
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Exception [{0}] getting int", e.GetType());
                }
            }
        }

        static public void Ex1()
        {
            /*
            while (true)
            {
                Console.WriteLine("Enter a value or \"quit\" to quit");
                string val = Console.ReadLine();
                if (val.ToUpper() == "QUIT" || val.ToUpper() == "EXIT")
                {
                    break;
                }
                Console.WriteLine("Check [{0}]", val);
                try
                {
                    int num = Convert.ToInt32(val);
                    if (num >=1 && num <= 10)
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine("Invalid");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception parsing val [{0}] --> [{1}]", val, e.GetType());
                }
            }
            /*/
            while (true)
            {
                try
                {
                    Console.Write("Enter a value or \"quit\" to quit: ");
                    string val = Console.ReadLine();
                    if (val.ToUpper() == "QUIT")
                    {
                        break;
                    }
                    int num = Convert.ToInt32(val);
                    if (num >= 1 && num <= 10)
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine("Invalid");
                    }
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Exception parsing val [{0}]", e.GetType());
                }
            }
            //*/
        }

        static public void Ex2()
        {
            while (true)
            {
                try
                {
                    Console.Write(" Enter first number: ");
                    string str1 = Console.ReadLine();
                    if (str1.ToUpper() == "QUIT")
                        break;
                    int num1 = Convert.ToInt32(str1);
                    Console.Write("Enter second number: ");
                    string str2 = Console.ReadLine();
                    if (str2.ToUpper() == "QUIT")
                        break;
                    int num2 = Convert.ToInt32(str2);
                    Console.WriteLine("Max value = [{0}]", num1 > num2 ? num1 : num2);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Exception parsing val [{0}]", e.GetType());
                }
            }
        }

        static void Main(string[] args)
        {
            Exercise ex1 = new Exercise("Integer validation exercise",
                "Write a program and ask the user to enter a number. The number should be between 1 to 10. If the user enters a valid number, display \"Valid\" on the console. Otherwise, display \"Invalid\". (This logic is used a lot in applications where values entered into input boxes need to be validated.)");
            // Console.WriteLine(ex.ToString());
            Console.WriteLine(ex1);
            Ex1();

            Exercise ex2 = new Exercise("Get max int exercise",
                "Write a program which takes two numbers from the console and displays the maximum of the two.");
            // Console.WriteLine(ex.ToString());
            Console.WriteLine(ex2);
            Ex2();
        }
    }
}
