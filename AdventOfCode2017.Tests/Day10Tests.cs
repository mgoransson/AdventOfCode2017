using System;
using System.Linq;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class Day10Tests
    {
        [Fact]        
        public void Part01() 
        {
            // Arrange
            var input = "3, 4, 1, 5";
            var elements = new[] { 0, 1, 2, 3, 4 };

            // Act
            int actual = Day10.Part01(input, elements);

            // Assert
            Assert.Equal(12, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {    
            // Arrange
            var input = Day10.ReadInput();
            var elements = Enumerable.Range(0, 256).ToArray();

            // Act
            int actual = Day10.Part01(input, elements);

            // Assert
            Assert.Equal(1935, actual);
        }


        [Theory]
        [InlineData("", "a2582a3a0e66e6e86e3812dcb672a272")]
        [InlineData("AoC 2017", "33efeb34ea91902bb2f59c9920caa6cd")]
        [InlineData("1,2,3", "3efbe78a8d82f29979031a4aa0b16a9d")]
        [InlineData("1,2,4", "63960835bcdc130f0b66d7ff4f6a5a8e")]
        public void Part02(string input, string expected) 
        {
            // Arrange
            var elements = Enumerable.Range(0, 256).ToArray();

            // Act
            string actual = Day10.Part02(input, elements);

            // Assert
            Assert.Equal(expected.ToLower(), actual.ToLower());
        }

        [Fact]
        public void Part02_Answer() 
        {     
            // Arrange
            var input = Day10.ReadInput();
            var elements = Enumerable.Range(0, 256).ToArray();

            // Act
            var actual = Day10.Part02(input, elements);

            // Assert
            Assert.Equal("dc7e7dee710d4c7201ce42713e6b8359", actual);
        }
    }
}
