using System;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class Day09Tests
    {
        [Theory]
        [InlineData("{}", 1)]
        [InlineData("{{{}}}", 6)]
        [InlineData("{{},{}}", 5)]
        [InlineData("{{{},{},{{}}}}", 16)]
        [InlineData("{<a>,<a>,<a>,<a>}", 1)]
        [InlineData("{{<ab>},{<ab>},{<ab>},{<ab>}}", 9)]
        [InlineData("{{<!!>},{<!!>},{<!!>},{<!!>}}", 9)]
        [InlineData("{{<a!>},{<a!>},{<a!>},{<ab>}}", 3)]
        public void Part01(string input, int expected) 
        {
            // Act
            int actual = Day09.Part01(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {    
            // Arrange
            var input = Day09.ReadInput();

            // Act
            int actual = Day09.Part01(input);

            // Assert
            Assert.Equal(9251, actual);
        }


        [Theory]
        [InlineData("{}", 0)]
        [InlineData("{<random characters>}", 17)]
        [InlineData("{<<<<>}", 3)]
        [InlineData("{<{!>}>}", 2)]
        [InlineData("{<!!>}", 0)]
        [InlineData("{<!!!>>}", 0)]
        [InlineData(@"{<{o""i!a,<{i<a>}", 10)]
        public void Part02(string input, int expected) 
        {
            // Act
            var actual = Day09.Part02(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Part02_Answer() 
        {     
            // Arrange
            var input = Day09.ReadInput();

            // Act
            var actual = Day09.Part02(input);

            // Assert
            Assert.Equal(4322, actual);
        }
    }
}
