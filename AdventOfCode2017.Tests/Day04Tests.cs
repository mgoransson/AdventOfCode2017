using System;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class Day04Tests
    {
        [Theory]
        [InlineData(new[] { "aa bb cc dd ee" }, 1)]
        [InlineData(new[] { "aa bb cc dd aa" }, 0)]
        [InlineData(new[] { "aa bb cc dd aaa" }, 1)]
        public void Part01(string[] input, int expected) 
        {
            // Act
            int actual = Day04.Part01(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {    
            // Arrange
            var input = Day04.ReadInput();

            // Act
            var actual = Day04.Part01(input);

            // Assert
            Assert.Equal(383, actual);
        }


        [Theory]
        [InlineData(new[] { "abcde fghij" }, 1)]
        [InlineData(new[] { "abcde xyz ecdab" }, 0)]
        [InlineData(new[] { "a ab abc abd abf abj" }, 1)]
        [InlineData(new[] { "iiii oiii ooii oooi oooo" }, 1)]
        [InlineData(new[] { "oiii ioii iioi iiio" }, 0)]
        public void Part02(string[] input, int expected) 
        {
            // Act
            int actual = Day04.Part02(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Part02_Answer() 
        {     
            // Arrange
            var input = Day04.ReadInput();

            // Act
            var actual = Day04.Part02(input);

            // Assert
            Assert.Equal(265, actual);
        }
    }
}
