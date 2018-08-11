using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class Gradebook //members of this project (Grades)
    {
        public Gradebook() //gradebook constructor
        {
            _name = "Empty";
            grades = new List<float>(); //defines a list of grades that is of type float
        }

        public GradeStatistics ComputeStatistics() //method returns an object of type Gradestatistics (min, max, average etc)       
        {
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

        public void AddGrade(float grade) //members of this class holds a state and a behavior
        {
            grades.Add(grade);
        }

        public void RemoveGrade(float grade)
        {
            grades.Remove(grade);
        }

        public string Name //auto implemented propery. Compiler automatically creates a field to store the property
        {
            get
            {
                return _name; //if someone wants the name, returns the private string _name
            }
            set
            {
                if(!String.IsNullOrEmpty(value)) //validation against null input
                {
                    if(_name != value)
                    {
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.ExistingName = _name;
                        args.NewName = value; //will equal incoming value

                        NameChanged(this, args);
                    }

                    _name = value;
                }
                else
                {
                    Console.WriteLine("Generic Gradebook");
                }
            }
        }

        public event NameChangedDelegate NameChanged;
        private string _name;        
        public List<float> grades;
    }
}
