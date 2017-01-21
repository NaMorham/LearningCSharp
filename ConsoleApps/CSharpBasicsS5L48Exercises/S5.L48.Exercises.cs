using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CSharpBasicsS5L48Exercises
{
    class Exercise
    {
        public delegate void RunFunc();

        private string m_name;
        private string m_desc;
        private long m_id;
        private RunFunc m_testFunc;

        static private long ms_id_common = 1;
        static private List<Exercise> ms_exercises = new List<Exercise>();

        static public void addExercise(string name, string desc, RunFunc testFunc)
        {
            ms_exercises.Add(new Exercise(name, desc, testFunc));
        }

        static public void runAll()
        {
            foreach (Exercise ex in ms_exercises)
            {
                Console.WriteLine("{0}----------------\n{1}",
                    ex.getId() > 1 ? "\n\n" : "", ex);
                ex.m_testFunc();
            }
        }

        private Exercise(string name, string desc, RunFunc testFunc)
        {
            m_name = name;
            m_desc = desc;
            m_id = ms_id_common++;
            m_testFunc = testFunc;
        }

        public long getId()
        {
            return m_id;
        }

        override public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Exercise ").Append(m_id).Append("\n");
            sb.Append("Name: ").Append(m_name).Append("\n");
            sb.Append("Desc:\n");
            sb.Append(m_desc).Append("\n");
            return sb.ToString();
        }
    }

    class S5L48Exercises
    {
        static public void Ex1()
        {
            const int maxVal = 100;
            // calculated
            int num = maxVal / 3;
            Console.WriteLine("Calculated: {0}", num);

            // looping doom
            int count = 0;
            for (int i = 1; i <= maxVal; i++)
            {
                if (i % 3 == 0)
                    count++;
            }
            Console.WriteLine("Counted: {0}", count);
        }

        static public void Ex2()
        {
            float total = 0.0f;
            int count = 0;
            while (true)
            {
                try
                {
                    Console.Write("Enter a value or \"ok\" to finish: ");
                    string val = Console.ReadLine();
                    if (val.ToUpper() == "OK")
                    {
                        break;
                    }
                    float num = Convert.ToSingle(val);
                    total += num;
                    count++;
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Exception parsing val [{0}]", e.GetType());
                }
            }
            Console.WriteLine("Total of {0} numbers = {1}", count, total);
        }

        static public long Factorial(long num)
        {
            if (num > 1)
                return num * Factorial(num - 1);
            else
                return 1;
        }

        static public void Ex3()
        {
            long value = 0;
            while (true)
            {
                try
                {
                    Console.Write("Enter a positive integer value: ");
                    string val = Console.ReadLine();
                    value = Convert.ToInt64(val);
                    if (value < 1)
                    {
                        Console.WriteLine("Must be a poitive integer, try again");
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Exception parsing val [{0}]", e.GetType());
                }
            }
            Console.WriteLine("{0}! = {1}", value, Factorial(value));
        }

        static public void Ex4()
        {
            const int minVal = 1;
            const int maxVal = 10;

            int totalGuesses = 4;
            Random rgen = new Random();

            int i = 1;
            for (i = 1; i <= 100; i++)
            {
                Console.Write("{0,2}", rgen.Next(minVal, maxVal+1));
                if (i % 10 == 0)
                    Console.WriteLine(",");
                else
                    Console.Write(", ");
            }
            if (i % 10 == 0)
                Console.WriteLine();

            int value = rgen.Next(minVal, maxVal);
            Console.Error.WriteLine("[DBG] Random num = {0}", value);
            while (totalGuesses >= 0)
            {
                try
                {
                    Console.Write("Guess a number between {1} and {2}; {0} chances remaining: ",
                        totalGuesses, minVal, maxVal);
                    string val = Console.ReadLine();
                    int guess = Convert.ToInt32(val);
                    if (guess >= minVal && guess <= maxVal)
                    {
                        totalGuesses--;
                        if (value == guess)
                        {
                            Console.WriteLine("You won");
                            return;
                        }
                        else if (guess < value)
                        {
                            Console.WriteLine("Nope - Higher");
                        }
                        else
                        {
                            Console.WriteLine("Nope - Lower");
                        }
                    }
                    else
                    {
                        Console.Error.WriteLine("Your guess must be between {0} and {1}.  Try again", minVal, maxVal);
                    }
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Exception parsing val [{0}]", e.GetType());
                }
            }
            Console.WriteLine("You lose.  The number was {0}", value);
        }

        static public void Ex5()
        {
            //string intList = "5, 3, 8, 1, 4";
            string intList = Console.ReadLine();
            char[] seps = new char[] { ',', ' ', '.', ':', ';', '\t', '\n' };
            string[] nums = intList.Split(seps, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("Split to [{0}] values", nums.Length);

            int max = int.MinValue;
            foreach (string s in nums)
            {
                Console.WriteLine("Token {0}", s);
                int val = int.MinValue;
                try
                {
                    val = Convert.ToInt32(s);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Exception [{1}] processing token [{0}]", s, e.GetType());
                }
                if (val > max)
                    max = val;
            }
            Console.WriteLine("Max value in [{0}] is [{1}]", intList, max);
            
        }

        static void Main(string[] args)
        {
            Exercise.addExercise("Numbers div by 3",
                "Write a program to count how many numbers between 1 and 100 are divisible by 3 with no remainder. Display the count on the console.",
                Ex1);
            Exercise.addExercise("Prompt and sum",
                "Write a program and continuously ask the user to enter a number or \"ok\" to exit. Calculate the sum of all the previously entered numbers and display it on the console.",
                Ex2);
            Exercise.addExercise("Factorial",
                "Write a program and ask the user to enter a number. Compute the factorial of the number and print it on the console. For example, if the user enters 5, the program should calculate 5 x 4 x 3 x 2 x 1 and display it as 5! = 120",
                Ex3);
            Exercise.addExercise("Guess a number between 1 and 10",
                "Write a program that picks a random number between 1 and 10. Give the user 4 chances to guess the number. If the user guesses the number, display \"You won\"; otherwise, display \"You lost\". (To make sure the program is behaving correctly, you can display the secret number on the console first.)",
                Ex4);
            Exercise.addExercise("Find max",
                "Write a program and ask the user to enter a series of numbers separated by comma. Find the maximum of the numbers and display it on the console. For example, if the user enters \"5, 3, 8, 1, 4\", the program should display 8.",
                Ex5);

            Exercise.runAll();
        }
    }
}
