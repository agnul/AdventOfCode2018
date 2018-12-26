using System;
using System.IO;

namespace AdventOfCode2018
{
    public class Program
    {
        private static readonly Day1Solver Day1 = new Day1Solver();
        private static readonly Day2Solver Day2 = new Day2Solver();
        private static readonly Day3Solver Day3 = new Day3Solver();

        public static void Main(string[] args)
        {
            var day1Input = Day1.ParseInput(File.ReadAllLines("data/day1.txt"));

            var result1 = Day1.SolvePart1For(day1Input);
            var result2 = Day1.SolvePart2For(day1Input);

            Console.WriteLine("Day 1 Solutions:");
            Console.WriteLine($"  part 1: {result1}");
            Console.WriteLine($"  part 2: {result2}");

            var day2Input = File.ReadAllLines("data/day2.txt");

            var result3 = Day2.SolvePart1For(day2Input);
            var result4 = Day2.SolvePart2For(day2Input);

            Console.WriteLine("Day 2 Solutions:");
            Console.WriteLine($"  part 1: {result3}");
            Console.WriteLine($"  part 2: {result4}");

            var day3Input = File.ReadAllLines("data/day3.txt");
            var result5 = Day3.SolvePart1For(day3Input);
            var result6 = Day3.SolvePart2For(day3Input);

            Console.WriteLine("Day 3 Solutions:");
            Console.WriteLine($"  part 1: {result5}");
            Console.WriteLine($"  part 2: {result6}");

            var day5Input = File.ReadAllLines("data/day5.txt");
            var result9 = Day5Solver.SolvePart1For(day5Input[0]);
            var result10 = Day5Solver.SolvePart2For(day5Input[0]);

            Console.WriteLine("Day 5 Solutions:");
            Console.WriteLine($"  part 1: {result9}");
            Console.WriteLine($"  part 2: {result10}");
        }
    }
}
