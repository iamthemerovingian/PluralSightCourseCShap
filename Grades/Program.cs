using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1 = new GradeBook();
            g1.Name = "Milinda's Grade Book";
            Console.WriteLine(g2.Name);
            */
            
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("Hello this is the green book program");
            GradeBook book = new GradeBook();
            book.AddGrade(91);
            book.AddGrade(89.5f);


            GradeBook book2 = book; // This does not create a copy of Book in the variable book 2!! It acutally copies the adderess of Book to book2 so you now have 2 variables poinitng to 1 object!! crazy!!
            book2.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();

            Console.WriteLine("AVG: " + stats.AverageGrade);
            Console.WriteLine("Max: " + stats.HighiestGrade);
            Console.WriteLine("MIN: " + stats.LowestGrade);
            
        }
    }


}
