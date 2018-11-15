using System;
using System.Linq;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class Day17Tests
    {
        [Fact]
        public void Part01() 
        {
            // Arrange
            var input = "3";

            // Act
            var actual = Day17.Part01(input);

            // Assert
            Assert.Equal(638, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {    
            // Arrange
            var input = Day17.ReadInput();

            // Act
            var actual = Day17.Part01(input);

            // Assert
            Assert.Equal(136, actual);
        }


        [Fact]
        public void Part02_Answer() 
        {
            // Arrange
            var input = Day17.ReadInput();

            // Act
            var actual = Day17.Part02(input);

            // Assert
            Assert.Equal(1080289, actual);
        }
    }
}
