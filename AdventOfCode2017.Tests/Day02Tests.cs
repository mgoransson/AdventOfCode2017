using System;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class Day02Tests
    {
        [Theory]
        [InlineData(new [] {"5\t1\t9\t5"}, 8)]
        [InlineData(new [] {"7\t5\t3"}, 4)]
        [InlineData(new [] {"2\t4\t6\t8"}, 6)]
        [InlineData(new [] {"5\t1\t9\t5", "7\t5\t3", "2\t4\t6\t8"}, 18)]
        public void Part01(string[] input, int expected) 
        {
            // Act
            int actual = Day02.Part01(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {    
            // Arrange
            var input = Day02.ReadInput();

            // Act
            var actual = Day02.Part01(input);

            // Assert
            Assert.Equal(36766, actual);
        }


        [Theory]
        [InlineData(new [] { "5\t9\t2\t8" }, 4)]
        [InlineData(new [] { "9\t4\t7\t3" }, 3)]
        [InlineData(new [] { "3\t8\t6\t5" }, 2)]
        [InlineData(new [] { "5\t9\t2\t8", "9\t4\t7\t3", "3\t8\t6\t5" }, 9)]
        public void Part02(string[] input, int expected) 
        {
            // Act
            int actual = Day02.Part02(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Part02_Answer() 
        {     
            // Arrange
            var input = Day02.ReadInput();

            // Act
            var actual = Day02.Part02(input);

            // Assert
            Assert.Equal(261, actual);
        }
    }
}
