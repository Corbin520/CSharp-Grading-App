
// Over view of page:
    // Out goal is to write a unit test to test our code to make sure it is working correctly.
        // The Goal here is to exexcute this unit test which places these three grades into a book, trys to get the statistics
        // and then we write assertions to make sure we are computing the correct results.

using System;

// Bringing in our xunit test
using Xunit;

namespace GradeBook.Test
{
    public class BookTests
    {
        // Making our unit test "public" so we can access it from anywhere in the application
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
                // we places these three grades into a book
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // Act
                // computes the average grade, highest grade and lowest grade
            var result = book.GetStatistics();


            // assert
                // then we write assertions to make sure we are computing the correct results
                // "1" is just saying we only want one decimal point back after the returned number
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);

        }
    }
}

