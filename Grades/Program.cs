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
            book.NameChanged += new NameChangedDelegate(OnNameChanged); //calls OnNameChanged every time someone invokes NamedChangedDelegate
            //+= add methods to invoke. Delegates can invoke multiple methods

            book.Name = "Some Gradebook";
            book.Name = "Diego's Gradebook";

            book.AddGrade(91);
            book.AddGrade(89.5f); //Since we declared it as a float, we need to append it with an f 
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();     //stores reference of the computed results to the stats variable
            Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);     //picks the method that uses the most sense
            WriteResult("Highest", (int) stats.HighestGrade); //explicitly converts it to int. Result will be truncated if not an int.
            WriteResult("Lowest", stats.LowestGrade);
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        }

        static void WriteResult(string description, int result)
        {
            Console.WriteLine($"{ description}: {result}");
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine("{0}: {1:F2}", description, result);
        }
    }
}
