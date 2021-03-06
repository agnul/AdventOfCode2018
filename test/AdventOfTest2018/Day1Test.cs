using System.Collections.Generic;

using Xunit;

using AdventOfCode2018;

namespace AdventOfTest2018
{
    public class Day1Test
    {
        private readonly Day1Solver _day1 = new Day1Solver();

        [Fact]
        public void ItParsesInput()
        {
            string[] input = { "1", "-2", "3"};
            var expected = new List<int> { 1, -2, 3};

            Assert.Equal(expected, _day1.ParseInput(input));
        }

        [Fact]
        public void ItWorksOnTheFirstSample()
        {
            Assert.Equal(3, _day1.SolvePart1For(new List<int> { 1, 1, 1}));
        }

        [Fact]
        public void ItWorksOnTheSecondSample()
        {
            Assert.Equal(0, _day1.SolvePart1For(new List<int> { 1, 1, -2}));
        }

        [Fact]
        public void ItSolvesPart2ForTheFirstSample() {

            Assert.Equal(0, _day1.SolvePart2For(new List<int> {1, -1}));

        }

        [Fact]
        public void ItSolvesPart2ForTheSecondSample() {

            Assert.Equal(10, _day1.SolvePart2For(new List<int> {3, 3, 4, -2, -4}));

        }
    }
}
