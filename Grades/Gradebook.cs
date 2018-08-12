using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook : GradeTracker //members of this project (Grades)
    {
        public GradeBook() //gradebook constructor
        {
            _name = "Empty";
            grades = new List<float>(); //defines a list of grades that is of type float
        }

        public override GradeStatistics ComputeStatistics() //method returns an object of type Gradestatistics (min, max, average etc)  
        // No longer uses a variable to figure out what method to call, instead uses the type of object. The type that it sees at runtime.    
        {
            Console.WriteLine("Gradebook::ComputeStatistics"); //Test. Shows where the code is

            GradeStatistics stats = new GradeStatistics();
            float sum = 0;
            foreach (float grade in grades) //for each grade in the gradebook, please take that grade and put it into a variable for me
            {
                //if the grade is greater than highest grade, then execute assignment
                //if (grade > stats.HighestGrade)
                //{
                //    stats.HighestGrade = grade;
                //}
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade); //faster way to do above using .net library.
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade; //adds each grade and stores it in sum
            }
            stats.AverageGrade = sum / grades.Count;
            return stats;    //return new GradeStatistics(); this would return a new instance of gradestatistics 
        }

        public override void WriteGrades(TextWriter destination)
        {
            for (int i = grades.Count; i > 0; i--) //grades in reverse order
            {
                destination.WriteLine(grades[i - 1]);
            }
        }

        public override void AddGrade(float grade) //members of this class holds a state and a behavior
        {
            grades.Add(grade);
        }

        public void RemoveGrade(float grade)
        {
            grades.Remove(grade);
        }

        protected List<float> grades; 
        //public: anyone can acess protected: access from code in this class or code in a derived class private: code inside of the same class can acess
    }
}
