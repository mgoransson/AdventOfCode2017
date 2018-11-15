using System;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class Day06Tests
    {
        [Fact]
        public void Part01() 
        {
            // Arrange
            var input = new[] { 0, 2, 7, 0 };

            // Act
            int actual = Day06.Part01(input);

            // Assert
            Assert.Equal(5, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {    
            // Arrange
            var input = Day06.ReadInput();

            // Act
            var actual = Day06.Part01(input);

            // Assert
            Assert.Equal(14029, actual);
        }


        [Fact]
        public void Part02() 
        {
            // Arrange
            var input = new[] { 2, 4, 1, 2 };

            // Act
            int actual = Day06.Part02(input);

            // Assert
            Assert.Equal(4, actual);
        }

        [Fact]
        public void Part02_Answer() 
        {     
            // Arrange
            var input = Day06.ReadInput();

            // Act
            var actual = Day06.Part02(input);

            // Assert
            Assert.Equal(2765, actual);
        }
    }
}
