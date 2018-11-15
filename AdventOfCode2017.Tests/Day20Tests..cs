using System;
using System.Linq;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class Day20Tests
    {
        [Fact]
        public void Part01() 
        {
            // Arrange
            var input = new[] {
                "p=< 3,0,0>, v=< 2,0,0>, a=<-1,0,0>",
                "p=< 4,0,0>, v=< 0,0,0>, a=<-2,0,0>"
            };

            // Act
            var actual = Day20.Part01(input);

            // Assert
            Assert.Equal(0, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {    
            // Arrange
            var input = Day20.ReadInput();

            // Act
            var actual = Day20.Part01(input);

            // Assert
            Assert.Equal(91, actual);
        }


        [Fact]
        public void Part02() 
        {
            // Arrange
            var input = new[] {
                "p=<-6,0,0>, v=< 3,0,0>, a=< 0,0,0>",
                "p=<-4,0,0>, v=< 2,0,0>, a=< 0,0,0>",
                "p=<-2,0,0>, v=< 1,0,0>, a=< 0,0,0>",
                "p=< 3,0,0>, v=<-1,0,0>, a=< 0,0,0>"
            };

            // Act
            var actual = Day20.Part02(input);

            // Assert
            Assert.Equal(1, actual);
        }

        [Fact]
        public void Part02_Answer() 
        {
            // Arrange
            var input = Day20.ReadInput();

            // Act
            var actual = Day20.Part02(input);

            // Assert
            Assert.Equal(567, actual);
        }
    }
}
