using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasicsS5L42Exercises
{
    class Program
    {
        static public void Ex1(Exercise ex)
        {
            Console.WriteLine("--------------\n{0}", ex);
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
        }

        static public void Ex2(Exercise ex)
        {
            Console.WriteLine("\n\n--------------\n{0}", ex);
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

        static public void Ex3(Exercise ex)
        {
            Console.WriteLine("\n\n--------------\n{0}", ex);
            while (true)
            {
                try
                {
                    Console.Write(" Enter width: ");
                    string str1 = Console.ReadLine();
                    if (str1.ToUpper() == "QUIT")
                        break;
                    float width = Convert.ToSingle(str1);
                    Console.Write("Enter length: ");
                    string str2 = Console.ReadLine();
                    if (str2.ToUpper() == "QUIT")
                        break;
                    float length = Convert.ToSingle(str2);
                    if (width == length)
                    {
                        Console.WriteLine("Square");
                    }
                    else if (width > length)
                    {
                        Console.WriteLine("Landscape");
                    }
                    else
                    {
                        Console.WriteLine("Portrait");
                    }
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Exception parsing val [{0}]", e.GetType());
                }
            }
        }

        static public void Ex4(Exercise ex)
        {
            Console.WriteLine("\n\n--------------\n{0}", ex);
            while (true)
            {
                try
                {
                    Console.Write(" Enter limit: ");
                    string str1 = Console.ReadLine();
                    if (str1.ToUpper() == "QUIT")
                        break;
                    float speedLimit = Convert.ToSingle(str1);
                    Console.Write("Enter speed: ");
                    string str2 = Console.ReadLine();
                    if (str2.ToUpper() == "QUIT")
                        break;

                    float speed = Convert.ToSingle(str2);
                    if (speed < speedLimit) // as per spec, but wtf should be <=
                    {
                        Console.WriteLine("Ok");
                    }
                    else
                    {
                        double overSpeed = speed - speedLimit;
                        int demerits = (int)(overSpeed / 5.0);
                        Console.WriteLine("{0} demerit points{1}", demerits, demerits > 12 ? " License Suspended" : "");
                    }
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
            Ex1(ex1);

            Exercise ex2 = new Exercise("Get max int exercise",
                "Write a program which takes two numbers from the console and displays the maximum of the two.");
            Ex2(ex2);

            Exercise ex3 = new Exercise("Portrait or landscape", "Write a program and ask the user to enter the width and height of an image. Then tell if the image is landscape or portrait.");
            Ex3(ex3);

            Ex4(new Exercise("Speed camera", "Your job is to write a program for a speed camera. For simplicity, ignore the details such as camera, sensors, etc and focus purely on the logic. Write a program that asks the user to enter the speed limit. Once set, the program asks for the speed of a car. If the user enters a value less than the speed limit, program should display Ok on the console. If the value is above the speed limit, the program should calculate the number of demerit points. For every 5km/hr above the speed limit, 1 demerit points should be incurred and displayed on the console. If the number of demerit points is above 12, the program should display License Suspended."));
        }
    }
}
