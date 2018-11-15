using System;
using System.Linq;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class Day19Tests
    {
        [Fact]
        public void Part01() 
        {
            // Arrange
            var input = new[] {
                "     |           ",
                "     |  +--+     ",
                "     A  |  C     ",
                " F---|----E|--+  ",
                "     |  |  |  D  ",
                "     +B-+  +--+  "
            };

            // Act
            var actual = Day19.Part01(input);

            // Assert
            Assert.Equal("ABCDEF", actual);
        }

        [Fact]
        public void Part01_Answer() 
        {    
            // Arrange
            var input = Day19.ReadInput();

            // Act
            var actual = Day19.Part01(input);

            // Assert
            Assert.Equal("LXWCKGRAOY", actual);
        }


        [Fact]
        public void Part02() 
        {
            // Arrange
            var input = new[] {
                "     |           ",
                "     |  +--+     ",
                "     A  |  C     ",
                " F---|----E|--+  ",
                "     |  |  |  D  ",
                "     +B-+  +--+  "
            };

            // Act
            var actual = Day19.Part02(input);

            // Assert
            Assert.Equal(38, actual);
        }

        [Fact]
        public void Part02_Answer() 
        {
            // Arrange
            var input = Day19.ReadInput();

            // Act
            var actual = Day19.Part02(input);

            // Assert
            Assert.Equal(17302, actual);
        }
    }
}
