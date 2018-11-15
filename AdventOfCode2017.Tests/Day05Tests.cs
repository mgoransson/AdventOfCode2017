using System;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class Day05Tests
    {
        [Fact]
        public void Part01() 
        {
            //Arrange
            var input = new[] { 0, 3, 0, 1, -3 };

            // Act
            int actual = Day05.Part01(input);

            // Assert
            Assert.Equal(5, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {    
            // Arrange
            var input = Day05.ReadInput();

            // Act
            var actual = Day05.Part01(input);

            // Assert
            Assert.Equal(364539, actual);
        }


        [Fact]
        public void Part02()
        {
            // Arrange
            var input = new[] { 0, 3, 0, 1, -3 };

            // Act
            int actual = Day05.Part02(input);

            // Assert
            Assert.Equal(10, actual);
        }

        [Fact]
        public void Part02_Answer()
        {     
            // Arrange
            var input = Day05.ReadInput();

            // Act
            var actual = Day05.Part02(input);

            // Assert
            Assert.Equal(27477714, actual);
        }
    }
}
