using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2018
{
    class Program
    {
        private static readonly Day1Solver day1 = new Day1Solver();
        private static readonly Day2Solver day2 = new Day2Solver();
        private static readonly Day3Solver day3 = new Day3Solver();

        static void Main(string[] args)
        {
            var day1Input = day1.ParseInput(File.ReadAllLines("data/day1.txt"));

            var result1 = day1.SolvePart1For(day1Input);
            var result2 = day1.SolvePart2For(day1Input);

            Console.WriteLine("Day 1 Solutions:");
            Console.WriteLine($"  part 1: {result1}");
            Console.WriteLine($"  part 2: {result2}");

            var day2input = File.ReadAllLines("data/day2.txt");

            var result3 = day2.SolvePart1For(day2input);
            var result4 = day2.SolvePart2For(day2input);

            Console.WriteLine("Day 2 Solutions:");
            Console.WriteLine($"  part 1: {result3}");
            Console.WriteLine($"  part 2: {result4}");

            var day3input = File.ReadAllLines("data/day3.txt");
            var result5 = day3.SolvePart1For(day3input);
            var result6 = day3.SolvePart2For(day3input);

            Console.WriteLine("Day 3 Solutions:");
            Console.WriteLine($"  part 1: {result5}");
            Console.WriteLine($"  part 2: {result6}");
        }
    }
}
