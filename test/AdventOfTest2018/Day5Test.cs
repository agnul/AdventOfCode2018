using Xunit;

using AdventOfCode2018;

namespace AdventOfTest2018
{
    public class Day5Test
    {
        [Fact]
        public void ItReducesOneTime()
        {
            Assert.Equal("", Day5Solver.React("aA"));
        }

        [Fact]
        public void ItReducesToTheRight()
        {
            Assert.Equal("a", Day5Solver.React("abB"));
        }

        [Fact]
        public void ItReducesAllInOnePass()
        {
            Assert.Equal("cd", Day5Solver.React("aABbcdEe"));
        }

        [Fact]
        public void ItReducesTheExample()
        {
            Assert.Equal("dabCBAcaDA", Day5Solver.React("dabAcCaCBAcCcaDA"));
        }

        [Fact]
        public void ItSolvesPart1()
        {
            Assert.Equal(10, Day5Solver.SolvePart1For("dabAcCaCBAcCcaDA"));
        }

        [Fact]
        public void ItSolvesPart2()
        {
            Assert.Equal(4, Day5Solver.SolvePart2For("dabAcCaCBAcCcaDA"));
        }
    }
}
