using System;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class Day08Tests
    {
        [Fact]
        public void Part01() 
        {
            // Arrange
            var input =  new[] {
                "b inc 5 if a > 1",
                "a inc 1 if b < 5",
                "c dec -10 if a >= 1",
                "c inc -20 if c == 10"
            };

            // Act
            int actual = Day08.Part01(input);

            // Assert
            Assert.Equal(1, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {    
            // Arrange
            var input = Day08.ReadInput();

            // Act
            int actual = Day08.Part01(input);

            // Assert
            Assert.Equal(5849, actual);
        }


        [Fact]
        public void Part02() 
        {
            // Arrange
            var input =  new[] {
                "b inc 5 if a > 1",
                "a inc 1 if b < 5",
                "c dec -10 if a >= 1",
                "c inc -20 if c == 10"
            };

            // Act
            var actual = Day08.Part02(input);

            // Assert
            Assert.Equal(10, actual);
        }

        [Fact]
        public void Part02_Answer() 
        {     
            // Arrange
            var input = Day08.ReadInput();

            // Act
            var actual = Day08.Part02(input);

            // Assert
            Assert.Equal(6702, actual);
        }
    }
}
