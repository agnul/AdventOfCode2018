using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2018
{
    public class Day3Solver
    {
        private static readonly string ClaimPattern = @"#(\d+) @ (\d+),(\d+): (\d+)x(\d+)";
        private static readonly Cloth Cloth = new Cloth(1000, 1000);

        private List<Claim> _claims;
        
        private void _init(string[] input)
        {
            _claims = new List<Claim>();
            foreach (var i in input)
            {
                Claim? c = Parse(i);
                if (c.HasValue)
                {
                    _claims.Add(c.Value);
                }
            }
        }

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
            _init(input);
            foreach (var c in _claims)
            {
                Cloth.Place(c);
            }
            return Cloth.GetOverlap();
        }

        public string SolvePart2For(string[] input)
        {
            foreach (var c in _claims)
            {
                if (!Cloth.ClaimOverlaps(c))
                {
                    return c.Id;
                }
            }

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

        public bool ClaimOverlaps(Claim c)
        {
            var overlaps = false;
            for (var i = c.Origin.X; i < c.Origin.X + c.Area.Width; ++i) 
            {
                for (var j = c.Origin.Y; j < c.Origin.Y + c.Area.Height; ++j)
                {
                    overlaps = overlaps || map[i, j].Count > 1;
                }
            }

            return overlaps;
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