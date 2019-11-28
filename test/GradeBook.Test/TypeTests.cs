

using System;
using Xunit;

namespace GradeBook.Test
{

        
    public class TypeTests
    {





        // ***************************








        // delegates = A delegate is a reference type variable that holds the reference to a method.
        public delegate string WriteLogDelegate(string logMessage);


        // writing a test to show that we can point a delegate to a method
            // 1) create delegate 2) build method to match the delegate
            // 3) build a test 4) invoke our delegate and pass it a string
            // 5) test if it returns what we passed to it. (Assert)
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {

            // bring in WriteLogDelegate - delegate and store it to "log"
            WriteLogDelegate log;

            log = ReturnMessage;
            // 1) Create a WriteLogDelegate
            // 2) Point it to ReturnMessage() method
            // 3) Invoke log = lot() and pass it a peramiter type "string"
            // 4) It returns what you passed into it = "Hello!"


            // invoking log and pasing it "Hello!"
            var result = log("Hello!");


            // testing if our result and "Hello!" are equal
            Assert.Equal("Hello!", result);

        }

        // Build a method that will match our delegate WriteLogDelegate()
        // the method needs to take a string, and return a string
        string ReturnMessage(string message)
        {
            return message;


            
        }
        


        // easier example 







        // test delegate number, works

        // create delegate
        public delegate double doubleDelegate(double peram1);

        // test if they point to eachother
        [Fact]
        public void AnotherTest()
        {
            doubleDelegate wow;
            wow = ReturnNumber;
            var resultNum = wow(6);
            Assert.Equal(6, resultNum);

        }

        // create method to match delegate
        double ReturnNumber(double perams)
        {
            return perams;
        }
        




        // ***************************














        // ***** Here we are just passing values to eachother and testing to see what results we get *****
        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            // x is getting returned 3 from the GetInt() method.
            var x = GetInt();

            // SetInt() is reaching out to its method and getting the value of "z" because we are using the "ref" keyword. So ref "x" === "z=42"
            SetInt(ref x);

            Assert.Equal(42, x);
        }
        private void SetInt(ref int z)
        {
            z = 42;
        }
        private int GetInt()
        {
            return 3;
        }



        // ***************************




        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            // Strings cannot be re-asigned
            string name = "Corbin";
            var upper = UpperCase(name);

            Assert.Equal("Corbin", name);
            Assert.Equal("CORBIN", upper);
        }

        private string UpperCase(string peramiter)
        {
            return peramiter.ToUpper();
        }





        // ***************************



        // This test is showing that you can pass a reference by value
        [Fact]
        public void CSharpIsPassedByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            // We are constructing a new book instance AND setting the name by passing the name into the constructor
            // This line of code is constructing a new book object and we are storing a reference to that object in the book variable which is a peramitor to this method.
            book = new Book(name);
        }



        // ***************************




        // This test will check to see if we can change the name of a book
        // In this test, we are just invoking a method, and passing in a reference to book1 as well as a new string with "New Name"
            // RESULT: After the test was ran, I was able to see that i had the ability to change the name of an existing book object  
        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");

            // invoking our method SetName() and pass in the book as a peramiter, as well as passing a string of "New Name"
            // "book1" === SetName(book) &&& "New Name" === SetName(string name)
            // SetName is saying book1's name is now "New Name" and not "Book1" anymore
            SetName(book1, "New Name");

            // Finally, we can now assert that this "book" object referenced by book.1 does have that new name.
            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book, string name)
        {
            // this "books" name field should be === to the incoming names peramiter
            book.Name = name;
        }




        // ***************************




        // This test will tell us if GetBooks will return a different object each time its called.
        [Fact]
        public void GetBooksReturnsDifferentObjects()
        {
            // creating a variable called "book1" and invoke the method "GetBook()" and give it a new name "Book 1"
            // everytime GetBook() is invoked, it will create a new and unique, and distinked object in memmory.
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            // these two do NOT return the same object. They each return a new object. 
            // the code is correct. But if we did "Book 2" and then also "Book 2" the test would fail.
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }





        // ***************************




        // This test will tell us if we can get the same object reference with two different variables.
        [Fact]
        public void TwoVarsCanReferenceSameObject() 
        // We now know that two variables can reference the same object. 
        {
            var book1 = GetBook("Book 1");

            // We are setting "book2" to the value that "book1" has.
            // this line of code will do is take the value that is inside of "book1" (which is a pointer to the reference) and copy that value into the "book2" variable.
            // So we will have the same pointer value where a pointer is some number that will lead us to some memmory cell in our computer.
            var book2 = book1;

            Assert.Same(book1, book2);
        }

        // We want to return a book. The return type, is "Book".
        // We are going to pass in a string
        Book GetBook(string name)
        {
            // what we want todo is return an instance of the "Book" class and pass along the name peramiter.
            return new Book(name);
        }        
    }
}

// Other Notes
    // Pass By Reference is just passing the value of some data to another location in memmory as a reference. For example, your passing a basketball
        // to someone with a note tapped on it. They get the ball, as well as the contect of the note.
    // Value Type is not passing it. It is stored in its own variable. For example, var x=3. "x" will === 3 and stay with the x variable



