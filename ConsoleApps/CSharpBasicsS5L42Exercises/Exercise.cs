using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasicsS5L42Exercises
{
    class Exercise
    {
        private string m_name;
        private string m_desc;
        private long m_id;

        static private long ms_id_common = 1;

        public Exercise(string name, string desc)
        {
            m_name = name;
            m_desc = desc;
            m_id = ms_id_common++;
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
