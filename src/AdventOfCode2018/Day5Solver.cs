using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day5Solver
    {
        public static int SolvePart1For(string s)
        {
            return React(s).Length;
        }

        public static int SolvePart2For(string s)
        {
            return Enumerable.Range('a', 'z' - 'a' + 1)
                .Select(c => (char) c)
                .Select(c => React(s, c).Length)
                .Concat(new int[] { })
                .Min();
        }

        public static string React(string s, char? ignore = null)
        {
            var left = new Stack<char>();
            foreach (var c in s)
            {
                if (char.ToLower(c) == ignore) {continue;}

                if (left.Count != 0 && CanReact(left.Peek(), c))
                {
                    left.Pop();
                }
                else
                {
                    left.Push(c);
                }
            }

            return new string(left.Reverse().ToArray());
        }

        private static bool CanReact(char left, char c)
        {
            return char.ToLower(left) == char.ToLower(c);
        }
    }
}
