using System.Collections;
using System.IO;

namespace Grades
{
    internal interface IGradeTracker : IEnumerable
    //working with an iterface increases the flexibility of the software. 
    //wide variety of objects can be used
    {
        void AddGrade(float grade); //has no implementation details
        GradeStatistics ComputeStatistics();
        void WriteGrades(TextWriter destination);
        string Name { get; set; }
    }
}