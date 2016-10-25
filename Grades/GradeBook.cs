using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook //Internal classes can only be used by code in the same project. Public means any assembly can use this class.
    {
        public GradeBook()
        {
            name = "Unnamed Gradebook";
            grades = new List<float>();
        }
        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;

            foreach (float grade in grades)
            {
                stats.HighiestGrade = Math.Max(grade, stats.HighiestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count;

            return stats;
        }

        private string name;
        public string Name//This is a property.
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name Cannot be null or Empty");
                }

                //if (!string.IsNullOrWhiteSpace(value))
                //{
                if (name != value && NameChanged!= null)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = name;
                    args.Newname = value;

                    NameChanged(this, args);
                }
                name = value;
                //}
            }
        }

        //public NameChangedDelegate NameChanged;
        public event NameChangedDelegate NameChanged;

        private List<float> grades; // This is a field.

        public void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
            }
        }
    }
}
