using System;
using System.Linq;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class Day15Tests
    {
        [Fact]
        public void Part01() 
        {
            // Arrange
            var genA = 65;
            var genB = 8921;

            // Act
            int actual = Day15.Part01(genA, genB);

            // Assert
            Assert.Equal(588, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {    
            // Arrange
            var input = Day15.ReadInput();
            var formattedInput = Day15.FormatInput(input);

            // Act
            int actual = Day15.Part01(formattedInput.GeneratorA, formattedInput.GeneratorB);

            // Assert
            Assert.Equal(626, actual);
        }


        [Fact]
        public void Part02() 
        {
            // Arrange
            var genA = 65;
            var genB = 8921;

            // Act
            int actual = Day15.Part02(genA, genB);

            // Assert
            Assert.Equal(309, actual);
        }

        [Fact]
        public void Part02_Answer() 
        {     
            // Arrange
            var input = Day15.ReadInput();
            var formattedInput = Day15.FormatInput(input);

            // Act
            int actual = Day15.Part02(formattedInput.GeneratorA, formattedInput.GeneratorB);

            // Assert
            Assert.Equal(306, actual);
        }
    }
}
