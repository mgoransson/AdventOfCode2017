using System;
using System.Linq;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class Day16Tests
    {
        [Fact]
        public void Part01() 
        {
            // Arrange
            var input = "s1,x3/4,pe/b";
            var programs = "abcde";

            // Act
            string actual = Day16.Part01(input, programs);

            // Assert
            Assert.Equal("baedc", actual);
        }

        [Fact]
        public void Part01_Answer() 
        {    
            // Arrange
            var input = Day16.ReadInput();
            var programs = "abcdefghijklmnop";

            // Act
            string actual = Day16.Part01(input, programs);

            // Assert
            Assert.Equal("nlciboghjmfdapek", actual);
        }


        [Fact]
        public void Part02_Answer() 
        {
            // Arrange
            var input = Day16.ReadInput();
            var programs = "abcdefghijklmnop";

            // Act
            string actual = Day16.Part02(input, programs);

            // Assert
            Assert.Equal("nlciboghmkedpfja", actual);
        }
    }
}
