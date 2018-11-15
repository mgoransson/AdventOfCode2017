using System;
using System.Linq;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class Day11Tests
    {
        [Theory]        
        [InlineData("ne,ne,ne", 3)]
        [InlineData("ne,ne,sw,sw", 0)]
        [InlineData("ne,ne,s,s", 2)]
        [InlineData("se,sw,se,sw,sw", 3)]
        public void Part01(string input, int expected) 
        {
            // Act
            int actual = Day11.Part01(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {    
            // Arrange
            var input = Day11.ReadInput();

            // Act
            int actual = Day11.Part01(input);

            // Assert
            Assert.Equal(824, actual);
        }


        [Fact]
        public void Part02_Answer() 
        {     
            // Arrange
            var input = Day11.ReadInput();

            // Act
            var actual = Day11.Part02(input);

            // Assert
            Assert.Equal(1548, actual);
        }
    }
}
