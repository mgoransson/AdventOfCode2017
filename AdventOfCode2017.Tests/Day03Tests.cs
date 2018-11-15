using System;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class Day03Tests
    {
        [Theory]
        [InlineData(1, 0)]
        [InlineData(12, 3)]
        [InlineData(23, 2)]
        [InlineData(1024, 31)]
        public void Part01(int input, int expected) 
        {
            // Act
            int actual = Day03.Part01(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {    
            // Arrange
            var input = Day03.ReadInput();

            // Act
            var actual = Day03.Part01(input);

            // Assert
            Assert.Equal(480, actual);
        }


        [Theory]
        [InlineData(4, 5)]
        [InlineData(10, 11)]
        [InlineData(147, 304)]
        [InlineData(362, 747)]
        public void Part02(int input, int expected) 
        {
            // Act
            int actual = Day03.Part02(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Part02_Answer() 
        {     
            // Arrange
            var input = Day03.ReadInput();

            // Act
            var actual = Day03.Part02(input);

            // Assert
            Assert.Equal(349975, actual);
        }
    }
}
