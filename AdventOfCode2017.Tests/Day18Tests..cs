using System;
using System.Linq;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class Day18Tests
    {
        [Fact]
        public void Part01() 
        {
            // Arrange
            var input = new[] {
                "set a 1",
                "add a 2",
                "mul a a",
                "mod a 5",
                "snd a",
                "set a 0",
                "rcv a",
                "jgz a -1",
                "set a 1",
                "jgz a -2"
            };

            // Act
            long actual = Day18.Part01(input);

            // Assert
            Assert.Equal(4L, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {    
            // Arrange
            var input = Day18.ReadInput();

            // Act
            long actual = Day18.Part01(input);

            // Assert
            Assert.Equal(1187L, actual);
        }
    }
}
