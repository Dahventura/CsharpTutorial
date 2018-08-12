using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class ThrowAwayGradeBook : GradeBook //inherits from
    {
        public override GradeStatistics ComputeStatistics()
        //looks to see if the object will invoke this method and will effectively override it
        {
            Console.WriteLine("ThrowAwayGradebook");
            
            float lowest = float.MaxValue;
            foreach(float grade in grades)
            {
                lowest = Math.Min(grade, lowest);
            }
            grades.Remove(lowest);
            return base.ComputeStatistics();
        }
    }
}
