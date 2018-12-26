using System.Collections.Generic;

using Xunit;

using AdventOfCode2018;

namespace AdventOfTest2018
{
    public class Day7Test
    {
        private Day7Solver _day7 = new Day7Solver();

        [Fact]
        public void ItAddsARule()
        {
            _day7.AddRule("Step C must be finished before step A can begin.");

            Assert.Equal(new Step('A', new SortedSet<char>{'C'}), _day7.Steps['A']);
        }

        [Fact]
        public void ItAddsPredecessors()
        {
            _day7.AddRule("Step B must be finished before step E can begin.");
            _day7.AddRule("Step D must be finished before step E can begin.");
            _day7.AddRule("Step F must be finished before step E can begin.");

            Assert.Equal(new Step('E', new SortedSet<char> {'B', 'D', 'F'}), _day7.Steps['E']);
        }

        [Fact]
        public void ItSolvesTheExample()
        {
            _day7.AddRule("Step C must be finished before step A can begin.");
            _day7.AddRule("Step C must be finished before step F can begin.");
            _day7.AddRule("Step A must be finished before step B can begin.");
            _day7.AddRule("Step A must be finished before step D can begin.");
            _day7.AddRule("Step B must be finished before step E can begin.");
            _day7.AddRule("Step D must be finished before step E can begin.");
            _day7.AddRule("Step F must be finished before step E can begin.");

            Assert.Equal("CABDFE", _day7.ExecutionPlan());
        }
    }
}
