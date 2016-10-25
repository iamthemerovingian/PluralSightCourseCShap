using System;
using System.Collections.Generic;
using System.IO;
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

            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("Hello this is the green book program");

            IGradeTracker book = CreateGradebook();

            //GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);

            //book.NameChanged += new NameChangedDelegate(OnNameChanged);
            //book.NameChanged += new NameChangedDelegate(OnNameChanged2);
            //book.NameChanged += OnNameChanged;
            //book.NameChanged += OnNameChanged2;

            //book.NameChanged += OnNameChanged2; //This line adds one
            //book.NameChanged -= OnNameChanged2; //
            //book.NameChanged = null; This will not work with events.

            //book.Name = "Scott's Grade Book";
            //book.Name = "Milinda's Grade Book";
            //book.Name = null; // will not affect becasue we have added a validation step inside out Setter.
            //GradeBook book2 = book; // This does not create a copy of Book in the variable book 2!! It acutally copies the adderess of Book to book2 so you now have 2 variables poinitng to 1 object!! crazy!!
            //book2.AddGrade(75);

            //Console.WriteLine(book.Name); ;
            //Console.WriteLine("AVG: " + stats.AverageGrade);
            //Console.WriteLine("Max: " + stats.HighiestGrade);
            //Console.WriteLine("MIN: " + stats.LowestGrade);

            //book.WriteGrades(Console.Out);

        }

        private static IGradeTracker CreateGradebook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highiest", stats.HighiestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void SaveGrades(IGradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
            }
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(IGradeTracker book)
        {
            try
            {
                Console.WriteLine("Please enter a name: ");
                book.Name = Console.ReadLine();

            }
            catch (ArgumentException)
            {
                Console.WriteLine("you entered an invalid value");
                Console.WriteLine();
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //static void OnNameChanged(string existingName, string newName)
        //{
        //    Console.WriteLine($"Gradebook changing name from {existingName} to {newName}");
        //}
        //static void OnNameChanged2(string existingName, string newName)
        //{
        //    Console.WriteLine("**************");
        //}
        //static void OnNameChanged(object sender, NameChangedEventArgs args)
        //{
        //    Console.WriteLine($"Gradebook changing name from {args.ExistingName} to {args.Newname}");
        //}

        //static void WriteResult(string description, int result)
        //{
        //    Console.WriteLine(description + ": " + result);
        //}
        static void WriteResult(string description, string result)
        {
            Console.WriteLine("{0} : {1:C}", description, result);
            Console.WriteLine($"{description} : {result:C}");
        }
        static void WriteResult(string description, float result)
        {
            Console.WriteLine("{0} : {1:C}", description, result);
            Console.WriteLine($"{description} : {result:C}");
        }


    }


}
