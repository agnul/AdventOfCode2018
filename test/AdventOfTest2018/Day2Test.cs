using System;
using System.Collections.Generic;

using Xunit;

using AdventOfCode2018;

namespace AdventOfTest2018
{
    public class Day2Test
    {
        private Day2Solver day2 = new Day2Solver();

        [Fact]
        public void ItRecognizesStringsWithoutRepetitions()
        {
            Assert.Equal(Repetitions.None, day2.CountRepetitions("abcdef"));
        }

        [Fact]
        public void ItRecognizesStringsWithALetterRepeatedExactlyTwice()
        {
            Assert.Equal(Repetitions.Two, day2.CountRepetitions("abbcde"));
        }

        [Fact]
        public void ItRecognizesStringsWithALetterRepeatedExactlyThrice()
        {
            Assert.Equal(Repetitions.Three, day2.CountRepetitions("abcccd"));
        }

        [Fact]
        public void ItRecognizesStringsWithBothRepetitions()
        {
            Assert.Equal(Repetitions.TwoAndThree, day2.CountRepetitions("bababc"));
        }

        [Fact]
        public void ItSolvesPart1ForTheExample() 
        {
            Assert.Equal(12, day2.SolvePart1For(new string[] {
                "abcdef", "bababc", "abbcde", "abcccd", "aabcdd", "abcdee", "ababab"
            }));
        }

        [Fact]
        public void TwoIdsAreGoodIfTheyDifferByOneLetter()
        {
            Assert.Equal(true, day2.IdsAreGood("fghij", "fguij"));
        }

        [Fact]
        public void TwoIdsAreNotGoodIfTheyAreEqual() 
        {
            Assert.Equal(false, day2.IdsAreGood("abcde", "abcde"));
        }

        [Fact]
        public void TwoIdsAreNotGOodIfTheyDiffereByMoreThanOneLetter()
        {
            Assert.Equal(false, day2.IdsAreGood("abcde", "axcye"));
        }

        [Fact]
        public void ItReturnsCommonLetters() 
        {
            Assert.Equal("fgij", day2.CommonLetters("fghij", "fguij"));
        }

        [Fact]
        public void ItFindsTheGoodIds()
        {
            Assert.Equal("fgij", day2.SolvePart2For(new string[] {
                "abcde", "fghij", "klmno", "pqrst", "fguij", "axcye", "wvxyz"
            }));
        }
    }
}