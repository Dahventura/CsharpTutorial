using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class GradeTracker : IGradeTracker
    {
        public abstract void AddGrade(float grade); //has no implementation details
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);
        public abstract IEnumerator GetEnumerator();

        public string Name //auto implemented propery. Compiler automatically creates a field to store the property
        {
            get
            {
                return _name; //if someone wants the name, returns the private string _name
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty"); //terminates the program and promts a stack trace error msg
                }

                if (_name != value && NameChanged != null)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;  //will equal incoming value

                    NameChanged(this, args);
                }

                _name = value;

            }
        }

        public event NameChangedDelegate NameChanged;
        protected string _name;
    }
}
