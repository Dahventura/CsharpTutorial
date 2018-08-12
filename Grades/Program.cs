using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeTracker book = CreateGradeBook();

            GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);
        }

        private static GradeTracker CreateGradeBook()
        {
            //when using the new keyword, we are instantiating an instance of that class. In other words, creating an object
            //Instantiating a class invokes a method called a contructor. It constructs an object. Every class has a default constructor unless defined.
            return new ThrowAwayGradeBook(); //when declaring a new instance, it needs to be a concrete type
        }

        private static void WriteResults(GradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();     //stores reference of the computed results to the stats variable

            WriteResult("Average", stats.AverageGrade);     //picks the method that makes the most sense
            WriteResult("Highest", stats.HighestGrade); //explicitly converts it to int. Result will be truncated if not an int.
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void SaveGrades(GradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile); //sends an object to the WriteGrades method and stores it in the output file
            }
        }

        private static void AddGrades(GradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f); //Since we declared it as a float, we need to append it with an f 
            book.AddGrade(75);
        }

        private static void GetBookName(GradeTracker book)
        {
            try
            {
                Console.WriteLine("Enter a name");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Something went wrong!");
            }
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
