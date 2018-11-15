using System;
using Xunit;

namespace AdventOfCode2017.Tests
{
    public class Day07Tests
    {
        [Fact]
        public void Part01() 
        {
            // Arrange
            var input = new[] {
                "pbga (66)",
                "xhth (57)",
                "ebii (61)",
                "havc (66)",
                "ktlj (57)",
                "fwft (72) -> ktlj, cntj, xhth",
                "qoyq (66)",
                "padx (45) -> pbga, havc, qoyq",
                "tknk (41) -> ugml, padx, fwft",
                "jptl (61)",
                "ugml (68) -> gyxo, ebii, jptl",
                "gyxo (61)",
                "cntj (57)"
            };

            // Act
            string actual = Day07.Part01(input);

            // Assert
            Assert.Equal("tknk", actual);
        }

        [Fact]
        public void Part01_Answer() 
        {    
            // Arrange
            var input = Day07.ReadInput();

            // Act
            var actual = Day07.Part01(input);

            // Assert
            Assert.Equal("eugwuhl", actual);
        }
    }
}
