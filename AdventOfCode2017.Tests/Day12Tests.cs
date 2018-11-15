using System;
using System.Linq;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class Day12Tests
    {
        [Fact]        
        public void Part01() 
        {
            // Arrange
            var input = new[] {
                "0 <-> 2",
                "1 <-> 1",
                "2 <-> 0, 3, 4",
                "3 <-> 2, 4",
                "4 <-> 2, 3, 6",
                "5 <-> 6",
                "6 <-> 4, 5"
            };

            // Act
            int actual = Day12.Part01(input);

            // Assert
            Assert.Equal(6, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {    
            // Arrange
            var input = Day12.ReadInput();

            // Act
            int actual = Day12.Part01(input);

            // Assert
            Assert.Equal(130, actual);
        }


        [Fact]
        public void Part02() 
        {
            // Arrange
            var input = new[] {
                "0 <-> 2",
                "1 <-> 1",
                "2 <-> 0, 3, 4",
                "3 <-> 2, 4",
                "4 <-> 2, 3, 6",
                "5 <-> 6",
                "6 <-> 4, 5"
            };
            
            // Act
            int actual = Day12.Part02(input);

            // Assert
            Assert.Equal(2, actual);
        }

        [Fact]
        public void Part02_Answer() 
        {     
            // Arrange
            var input = Day12.ReadInput();

            // Act
            var actual = Day12.Part02(input);

            // Assert
            Assert.Equal(189, actual);
        }
    }
}
