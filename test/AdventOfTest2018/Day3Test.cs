using System;
using System.Collections.Generic;

using Xunit;

using AdventOfCode2018;

namespace AdventOfTest2018
{
    public class Day3Test 
    {
        private readonly Day3Solver day3 = new Day3Solver();

        [Fact]
        public void ItCanParseClaims()
        {
            Claim expected = new Claim("123", new Point(3, 2), new Area(4, 4));

            Assert.Equal(expected, day3.Parse("#123 @ 3,2: 4x4"));
        }

        [Fact]
        public void ItCanPlaceClaimsOnTheMap()
        {
            
            var map = new HashSet<string>[8,8];

            map[1,3] = new HashSet<string> { "1" };
            map[1,4] = new HashSet<string> { "1" };
            map[1,5] = new HashSet<string> { "1" };
            map[1,6] = new HashSet<string> { "1" };
            map[2,3] = new HashSet<string> { "1" };
            map[2,4] = new HashSet<string> { "1" };
            map[2,5] = new HashSet<string> { "1" };
            map[2,6] = new HashSet<string> { "1" };
            map[3,3] = new HashSet<string> { "1" };
            map[3,4] = new HashSet<string> { "1" };
            map[3,5] = new HashSet<string> { "1" };
            map[3,6] = new HashSet<string> { "1" };
            map[4,3] = new HashSet<string> { "1" };
            map[4,4] = new HashSet<string> { "1" };
            map[4,5] = new HashSet<string> { "1" };
            map[4,6] = new HashSet<string> { "1" };

            Claim c = new Claim("1", new Point(1, 3), new Area(4, 4));

            Assert.Equal(map, day3.Place(c, new HashSet<string>[8,8]));
        }

        [Fact]
        public void ItCanPlaceMultipleClaimsOnTheMap()
        {
            
            var map = new HashSet<string>[4,4];

            map[1, 1] = new HashSet<string> { "1" };
            map[1, 2] = new HashSet<string> { "1", "3" };
            map[2, 1] = new HashSet<string> { "1" };
            map[2, 2] = new HashSet<string> { "1", "2", "3" };

            map[2, 3] = new HashSet<string> { "2", "3" };
            map[3, 2] = new HashSet<string> { "2" };
            map[3, 3] = new HashSet<string> { "2" };

            map[1, 3] = new HashSet<string> { "3" };

            Claim c = new Claim("1", new Point(1, 1), new Area(2, 2));
            Claim d = new Claim("2", new Point(2, 2), new Area(2, 2));
            Claim e = new Claim("3", new Point(1, 2), new Area(2, 2));

            var result = new HashSet<string>[4,4];

            day3.Place(c, result);
            day3.Place(d, result);
            day3.Place(e, result);

            Assert.Equal(map, result);
        }

        [Fact]
        public void ItCountsTheArea() 
        {
            Claim c = new Claim("1", new Point(1, 1), new Area(2, 2));
            Claim d = new Claim("2", new Point(2, 2), new Area(2, 2));
            Claim e = new Claim("3", new Point(1, 2), new Area(2, 2));

            var result = new HashSet<string>[4,4];

            day3.Place(c, result);
            day3.Place(d, result);
            day3.Place(e, result);

            Assert.Equal(8, day3.ClaimedArea(result));
        }

        [Fact]
        public void ItCountsTheDisputedArea() 
        {
            Claim c = new Claim("1", new Point(1, 1), new Area(2, 2));
            Claim d = new Claim("2", new Point(2, 2), new Area(2, 2));
            Claim e = new Claim("3", new Point(1, 2), new Area(2, 2));

            var result = new HashSet<string>[4,4];

            day3.Place(c, result);
            day3.Place(d, result);
            day3.Place(e, result);

            Assert.Equal(3, day3.DisputedArea(result));
        }
    }
}