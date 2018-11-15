using System;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class Day01Tests
    {
        [Theory]
        [InlineData("1122", 3)]
        [InlineData("1111", 4)]
        [InlineData("1234", 0)]
        [InlineData("91212129", 9)]
        public void Part01(string input, int expected) 
        {
            // Act
            int actual = Day01.Part01(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {            
            // Arrange
            var input = Day01.ReadInput();

            // Act
            var actual = Day01.Part01(input);

            // Assert
            Assert.Equal(995, actual);
        }


        [Theory]
        [InlineData("1212", 6)]
        [InlineData("1221", 0)]
        [InlineData("123425", 4)]
        [InlineData("123123", 12)]
        [InlineData("12131415", 4)]
        public void Part02(string input, int expected) 
        {
            // Act
            int actual = Day01.Part02(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Part02_Answer() 
        {            
            // Arrange
            var input = Day01.ReadInput();

            // Act
            var actual = Day01.Part02(input);

            // Assert
            Assert.Equal(1130, actual);
        }
    }
}
