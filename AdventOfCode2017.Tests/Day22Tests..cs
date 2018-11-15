using System;
using System.Linq;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class Day22Tests
    {
        [Theory]
        [InlineData(new[] { "..#", "#..", "..." }, 70, 41)]
        [InlineData(new[] { "..#", "#..", "..." }, 10000, 5587)]
        public void Part01(string[] input, int bursts, int expected) 
        {
            // Act
            var actual = Day22.Part01(input, bursts);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {    
            // Arrange
            var input = Day22.ReadInput();
            var bursts = 10000;

            // Act
            var actual = Day22.Part01(input, bursts);

            // Assert
            Assert.Equal(5182, actual);
        }


        [Theory]
        [InlineData(new[] { "..#", "#..", "..." }, 100, 26)]
        [InlineData(new[] { "..#", "#..", "..." }, 10000000, 2511944)]
        public void Part02(string[] input, int bursts, int expected) 
        {
            // Act
            var actual = Day22.Part02(input, bursts);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Part02_Answer() 
        {
            // Arrange
            var input = Day22.ReadInput();
            var bursts = 10000000;

            // Act
            var actual = Day22.Part02(input, bursts);

            // Assert
            Assert.Equal(2512008, actual);
        }
    }
}
