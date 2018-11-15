using System;
using System.Linq;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class Day14Tests
    {
        [Fact]
        public void Part01() 
        {
            // Arrange
            var input = "flqrgnkx";

            // Act
            int actual = Day14.Part01(input);

            // Assert
            Assert.Equal(8108, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {    
            // Arrange
            var input = Day14.ReadInput();

            // Act
            int actual = Day14.Part01(input);

            // Assert
            Assert.Equal(8204, actual);
        }
    }
}
