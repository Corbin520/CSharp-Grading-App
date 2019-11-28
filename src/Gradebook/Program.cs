


using System;
using System.Collections.Generic;
using GradeBook;


// This is going to be our Main page that will run when we execute out page.
    // the goal of this page is to just bring in other files so we can keep this clean and
    // so that when we come back to this application, we can understand what its doing
namespace Gradebook
{


    class Program
    {
        
        static void Main(string[] args)
        {
            // giving our book a name
            var book = new Book("Corbins Grade Book");


            // each time a grade is added, store the onGradeAdded() = just returns a string telling the user added something then write out the text to the console
            book.GradeAdded += OnGradeAdded;

            // running our EnterGrades in the Main Method
            EnterGrades(book);


            // bringing in our "GetStatistics" which will compute and return the statistics (average, low and high grades)
            var stats = book.GetStatistics();

            // All we are doing here is displaying our results to the console
            Console.WriteLine($"The low grade is: { stats.Low }");
            Console.WriteLine($"The high grade is: { stats.High }");
            Console.WriteLine($"The average grade is: { stats.Average }");
            Console.WriteLine($"The letter grade is: { stats.Letter }");
        }









        // Method that will handle the grades when entered
        private static void EnterGrades(Book book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                // If the user enters in "q" in the console, it will quit asking for grades and then it will compute the high, low and average and return it to the user
                if (input == "q")
                {
                    // if "q", break out of the loop
                    break;
                }
                // try to run the following lines of code && try to execute these
                try
                {
                    // parse the number that was entered in our input (readLine) and store it to grade
                    var grade = double.Parse(input);

                    // Now we add the grade to the AddGrade()
                    book.AddGrade(grade);
                }
                // The try statement might throw an exception. So now i use the catch statement to try and catch the exception IF it throws one
                catch (ArgumentException ex)
                {
                    // This is useful because if there is an invalid entry, it will just catch the error and start over. So instead of crashing the program,
                    // i just inform the user that its incorrect and to try again.
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // This will run no matter what, successfully or not
                    // Console.WriteLine("***");
                }
            }
        }

        // what we want called once a grade has been added to the gradebook
        static void OnGradeAdded(object sender, EventArgs e)
        {
            // Tell the user that the grade was added
            Console.WriteLine("A grade was added");
        }

        // raising the event = invoking the delegate
        // handling the event = is really just using the "+=" operator to add a method into the invocation list
    }
}
