using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook : GradeTracker //Internal classes can only be used by code in the same project. Public means any assembly can use this class.
    {
        public GradeBook()
        {
            name = "Unnamed Gradebook";
            grades = new List<float>();
        }
        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }
        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("Inside the normal gradebook");
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

        protected List<float> grades; // This is a field. Protected keyoword means that if a class derives from this class, it can use this field.
        public override void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
            }
        }

        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }
    }
}
