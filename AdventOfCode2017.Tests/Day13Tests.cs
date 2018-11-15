using System;
using System.Linq;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class Day13Tests
    {
        [Fact]        
        public void Part01() 
        {
             // Arrange
            var input = new[] {
                "0: 3",
                "1: 2",
                "4: 4",
                "6: 4"
            };

            // Act
            int actual = Day13.Part01(input);

            // Assert
            Assert.Equal(24, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {    
            // Arrange
            var input = Day13.ReadInput();

            // Act
            int actual = Day13.Part01(input);

            // Assert
            Assert.Equal(2160, actual);
        }


        [Fact]
        public void Part02() 
        {
            // Arrange
            var input = new[] {
                "0: 3",
                "1: 2",
                "4: 4",
                "6: 4"
            };

            // Act
            int actual = Day13.Part02(input);

            // Assert
            Assert.Equal(10, actual);
        }

        [Fact]
        public void Part02_Answer() 
        {     
            // Arrange
            var input = Day13.ReadInput();

            // Act
            var actual = Day13.Part02(input);

            // Assert
            Assert.Equal(3907470, actual);
        }
    }
}
