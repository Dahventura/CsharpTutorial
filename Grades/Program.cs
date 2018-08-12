using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            //when using the new keyword, we are instantiating an instance of that class. In other words, creating an object
            //Instantiating a class invokes a method called a contructor. It constructs an object. Every class has a default constructor unless defined.
            Gradebook book = new Gradebook();
            book.Name = "Null";

            book.AddGrade(91);
            book.AddGrade(89.5f); //Since we declared it as a float, we need to append it with an f 
            book.AddGrade(75);
            book.WriteGrades(Console.Out); //sends an object to the WriteGrades method 

            GradeStatistics stats = book.ComputeStatistics();     //stores reference of the computed results to the stats variable

            WriteResult("Average", stats.AverageGrade);     //picks the method that makes the most sense
            WriteResult("Highest", stats.HighestGrade); //explicitly converts it to int. Result will be truncated if not an int.
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{ description}: {result}");
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{ description}: {result:F2}");
        }
    }
}
