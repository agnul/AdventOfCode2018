using System.Collections.Generic;
using System.Net.WebSockets;
using Xunit;

using AdventOfCode2018;

namespace AdventOfTest2018
{
    public class ClothTest
    {
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

            var c = new Claim("1", new Point(1, 3), new Area(4, 4));

            var cloth = new Cloth(8, 8);

            cloth.Place(c);

            Assert.Equal(map, cloth.Map);
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

            var c = new Claim("1", new Point(1, 1), new Area(2, 2));
            var d = new Claim("2", new Point(2, 2), new Area(2, 2));
            var e = new Claim("3", new Point(1, 2), new Area(2, 2));

            var cloth = new Cloth(4,4);

            cloth.Place(c);
            cloth.Place(d);
            cloth.Place(e);

            Assert.Equal(map, cloth.Map);
        }
        [Fact]
        public void ItCountsTheArea() 
        {
            var c = new Claim("1", new Point(1, 1), new Area(2, 2));
            var d = new Claim("2", new Point(2, 2), new Area(2, 2));
            var e = new Claim("3", new Point(1, 2), new Area(2, 2));

            var cloth = new Cloth(4,4);

            cloth.Place(c);
            cloth.Place(d);
            cloth.Place(e);

            Assert.Equal(8, cloth.GetCoveredArea());
        }
        [Fact]
        public void ItCountsTheOverlapArea() 
        {
            var c = new Claim("1", new Point(1, 1), new Area(2, 2));
            var d = new Claim("2", new Point(2, 2), new Area(2, 2));
            var e = new Claim("3", new Point(1, 2), new Area(2, 2));

            var cloth = new Cloth(4,4);

            cloth.Place(c);
            cloth.Place(d);
            cloth.Place(e);

            Assert.Equal(3, cloth.GetOverlap());
        }

        [Fact]
        public void ItCanCheckForOverlaps()
        {
            var cloth = new Cloth(4, 4);
            
            var c = new Claim("1", new Point(1, 1), new Area(2, 2));
            var d = new Claim("2", new Point(2, 2), new Area(2, 2));
            var e = new Claim("3", new Point(1, 2), new Area(2, 2));
            var f = new Claim("4", new Point(0, 0), new Area(1, 1));

            cloth.Place(c);
            cloth.Place(d);
            cloth.Place(e);
            
            Assert.True(cloth.ClaimOverlaps(c));
            Assert.True(cloth.ClaimOverlaps(d));
            Assert.True(cloth.ClaimOverlaps(e));
            Assert.False(cloth.ClaimOverlaps(f));
        }
    }
    public class Day3Test 
    {
        private readonly Day3Solver _day3 = new Day3Solver();
        [Fact]
        public void ItCanParseClaims()
        {
            var expected = new Claim("123", new Point(3, 2), new Area(4, 4));

            Assert.Equal(expected, _day3.Parse("#123 @ 3,2: 4x4"));
        }
    }
}