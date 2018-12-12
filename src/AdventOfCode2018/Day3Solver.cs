using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2018
{
    public class Day3Solver
    {
        private static readonly string ClaimPattern = @"#(\d+) @ (\d+),(\d+): (\d+)x(\d+)";
        private static readonly Cloth Cloth = new Cloth(1000, 1000);
        public Claim? Parse(string s)
        {
            var match = Regex.Match(s, ClaimPattern);
            if (match.Success)
            {
                return new Claim(
                    match.Groups[1].Value,
                    new Point(int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value)),
                    new Area(int.Parse(match.Groups[4].Value), int.Parse(match.Groups[5].Value))
                );
            }
            return null;
        }
        public int SolvePart1For(string[] input)
        {
            foreach (var i in input)
            {
                var c = Parse(i);
                if (c.HasValue)
                {
                    Cloth.Place(c.Value);
                }                
            }
            return Cloth.GetOverlap();
        }
        public string SolvePart2For(string[] input)
        {
            return "";
        }
    } 
    public class Cloth
    {
        private HashSet<string>[,]  map;
        public HashSet<string>[,]  Map => map;

        public Cloth(int width, int height)
        {
            map = new HashSet<string>[width, height];
        }
        public void Place(Claim c) 
        {
            for (var i = c.Origin.X; i < c.Origin.X + c.Area.Width; ++i) 
            {
                for (var j = c.Origin.Y; j < c.Origin.Y + c.Area.Height; ++j)
                {
                    if (map[i,j] == null)
                    {
                        map[i,j] = new HashSet<string>();
                    }
                    map[i,j].Add(c.Id);
                }
            }
        }
        public int GetCoveredArea()
        {
            var area = 0;
            for (var i = 0; i < map.GetLength(0); ++i) 
            {
                for (var j = 0; j < map.GetLength(1); ++j) 
                {
                    if (map[i,j] != null && map[i,j].Count != 0)
                    {
                        ++area;
                    }
                }
            }
            return area;
        }
        public int GetOverlap()
        {
            var area = 0;
            for (var i = 0; i < map.GetLength(0); ++i) 
            {
                for (var j = 0; j < map.GetLength(1); ++j) 
                {
                    if (map[i,j] != null && map[i,j].Count > 1)
                    {
                        ++area;
                    }
                }
            }
            return area;
        }
        public string FindNonOverlappingClaim()
        {
            var id = "";
            for (var i = 0; i < map.GetLength(0); ++i) 
            {
                for (var j = 0; j < map.GetLength(1); ++j) 
                {
                    if (map[i,j] != null && map[i,j].Count == 1)
                    {
                        id = map[i,j].First();
                        foreach (var s in map[i,j])
                        {
                            Console.Write($"{s}, ");
                        }
                        Console.WriteLine();
                    }
                }
            }
            return id;
        }
    }
    public struct Claim{
        public string Id;

        public Point Origin;

        public Area Area;

        public Claim(string id, Point origin, Area area)
        {
            Id = id;
            Origin = origin;
            Area = area;
        }
    }
    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    public struct Area
    {
        public int Width;

        public int Height;

        public Area(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}