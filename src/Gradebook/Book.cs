
// Psudo Code Done

using System;
using System.Collections.Generic;

namespace GradeBook
{
    // delegate decloration that will be used to add grades
    public delegate void GradeAddedDelegate(object sender, EventArgs args);


    // inharatance | Base Class. This class can be used in multiple different ways. Right noow we are using it for 
    // name of a book, but we can also use it for anything like, employee name, grade name or anything with a name
    // Now we dont need to write this more then once.


        // Creating the name so that we can use it in multiple places of the application so we do not have to keep writing out the name
        public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }


        public string Name
        {
            get;
            set;
        }
    }


    public class Book : NamedObject
    {
        // base : A way to reference your base class
        // base = NamedObject() method
        public Book(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }


        // What we are doing here, is a switch statement that takes in a case, and will call the AddGrade() method and pass in a value based off the case value
        public void AddLetterGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        // AddGrade() is a method we built that will let us add grades to our gradeboook. We will call this method when a user wants to add a grade into the book.
        public void AddGrade(double grade)
        {
            // Here i am just saying that the grade needs to be between 0-100.
            if (grade <= 100 && grade >= 0)
            {
                // if the grade is between 0-100, add the grade to grades
                grades.Add(grade);
                
                // if the grade has a value, or is NOT null, then tell the user that the grade has been added
                if(GradeAdded != null)
                {
                    // this is talking to our delegate
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                // If the grade is not between 0-100, i inform the user that it is an invalid entry and to try again
                throw new ArgumentException($"Invalid {nameof(grade)} ");
            }
        }



        public event GradeAddedDelegate GradeAdded;



        // TAKING OUR VALUES, LOOPING OVER THEM, GIVING THE RESULT AND CALCULATONS
        public Statistics GetStatistics()
        {
            
            var result = new Statistics();


            // When we begin our loop, we want to start with the lowest number. That was when it begins, the first number is higher then our starting value
            result.High = double.MinValue;
            
            // Same as above, but starting at the highest possible value
            result.Low = double.MaxValue;

            
            for(var index = 0; index < grades.Count; index += 1)
            {
                // result.High is going to take the highest value between grades[index] and results.High and store it to the "result.High"
                result.High = Math.Max(grades[index], result.High);

                // same as result.High, but we are taking the lowest grade between the two and storing it to results.Low
                result.Low = Math.Min(grades[index], result.Low);

                // Storing each grade at each index to result.Average (this will end up being each value that is added to AddGrade() Method)
                result.Average += grades[index];

            }
            // This is looping through our grades array, getting the value of each item then deviding it by the items in the array using the count
                // count just will give us the number of items in the array and not the value. 
            result.Average /= grades.Count;


            // The switch statement will generate the average grade number and give it back a letter grade
                // example: if my average grades for the class are above 90, it will return the letter grade "A"
            switch(result.Average)
            {
                case var d when d >= 90:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }

            // Now we just return the result
            return result;
        }

        // We want a private list that will hold our grades
        private List<double> grades;


        // Readonly = what the readonly key word gives me is a field that i can only initialize or change or write to in the constructor.
        readonly string catagory;
    }
}

