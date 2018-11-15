using System;
using System.Linq;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class Day23Tests
    {
        [Fact]
        public void Part01_Answer() 
        {    
            // Arrange
            var input = Day23.ReadInput();

            // Act
            var actual = Day23.Part01(input);

            // Assert
            Assert.Equal(4225, actual);
        }
    }
}
