using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Exercises
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
}
