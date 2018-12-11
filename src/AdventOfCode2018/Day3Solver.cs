using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2018
{
    public class Day3Solver
    {
        private static readonly string ClaimPattern = @"#(\d+) @ (\d+),(\d+): (\d+)x(\d+)";
        private static readonly Cloth cloth = new Cloth(1000, 1000);
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
            else 
            {
                return null;
            }
        }
        public int SolvePart1For(string[] input)
        {
            foreach (var i in input)
            {
                Claim? c = Parse(i);
                if (c.HasValue)
                {
                    cloth.Place(c.Value);
                }                
            }
            return cloth.GetOverlap();
        }
        public string SolvePart2For(string[] input)
        {
            return "";
        }
    } 
    public class Cloth
    {
        private HashSet<string>[,]  map;
        public HashSet<string>[,]  Map
        {
            get { return map; }
        }
        public Cloth(int width, int height)
        {
            map = new HashSet<string>[width, height];
        }
        public void Place(Claim c) 
        {
            for (var i = c.origin.x; i < c.origin.x + c.area.width; ++i) 
            {
                for (var j = c.origin.y; j < c.origin.y + c.area.height; ++j)
                {
                    if (map[i,j] == null)
                    {
                        map[i,j] = new HashSet<string>();
                    }
                    map[i,j].Add(c.id);
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
        public string FindNonOverlappingClaim(HashSet<string>[,] map)
        {
            String id = "";
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
        public string id;

        public Point origin;

        public Area area;

        public Claim(string id, Point origin, Area area)
        {
            this.id = id;
            this.origin = origin;
            this.area = area;
        }
    }
    public struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public struct Area
    {
        public int width;

        public int height;

        public Area(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
    }
}