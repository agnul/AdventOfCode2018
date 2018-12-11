using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2018
{
    public class Day1Solver
    {
        public int SolvePart1For(List<int> input) 
        {
            return input.Sum();
        }
        public List<int> ParseInput(string[] input)
        {
            List<int> result = new List<int>();
            foreach (var s in input) 
            {
                result.Add(int.Parse(s));
            }
            return result;
        }
        public int SolvePart2For(List<int> input) {
            
            var sum = 0;
            var sums = new HashSet<int>() { 0 };

            foreach (var i in InputLoop(input)) 
            {
                sum += i;
                if (sums.Contains(sum)) 
                {
                    return sum;
                } else 
                {
                    sums.Add(sum);
                }
            }
            return -1;
        }

        public static IEnumerable<int> InputLoop(List<int> input)
        {
            while (true)
            {
                foreach (var i in input) 
                {
                    yield return i;
                }
            }
        }
    }
}
