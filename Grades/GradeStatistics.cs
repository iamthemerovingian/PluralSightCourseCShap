using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class GradeStatistics
    {
        public GradeStatistics()
        {
            HighiestGrade = float.MinValue;
            LowestGrade = float.MaxValue;
        }
        public float AverageGrade;
        public float HighiestGrade;
        public float LowestGrade;
    }
}
