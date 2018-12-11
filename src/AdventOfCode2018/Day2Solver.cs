using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day2Solver 
    {
        public Repetitions CountRepetitions(String s)
        {
            char? two = null;
            char? three = null;
            foreach(var c in s.ToCharArray())
            {
                var repeats = s.Count(x => x == c);
                if (repeats > 2) 
                {
                    three = c;
                }
                else if (repeats > 1)
                {
                    two = c;
                }
            }
            if (three != null && two != null && three != two) 
            {
                return Repetitions.TwoAndThree;
            }
            else if (three != null) 
            {
                return Repetitions.Three;
            }
            else if (two != null)
            {
                return Repetitions.Two;
            }
            else 
            {
                return Repetitions.None;
            }
        }

        public int SolvePart1For(string[] input)
        {
            var twos = 0;
            var threes = 0;

            foreach (var s in input) 
            {
                switch (CountRepetitions(s))
                {
                    case Repetitions.TwoAndThree:
                        ++threes;
                        ++twos;
                        break;
                    case Repetitions.Three:
                        ++threes;
                        break;
                    case Repetitions.Two:
                        ++twos;
                        break;
                    default:
                        break;
                }
            }
            return twos * threes;
        }
        public bool IdsAreGood(string id1, string id2)
        {
            var diff = 0;
            var size = id1.Length;
            for (var i = 0; i < size && diff < 2; ++i)
            {
                if (id1[i] != id2[i])
                {
                    ++diff;
                }
            }
            return diff == 1;
        }

        public string CommonLetters(string s, string t) 
        {
            char[] res = new char[s.Length - 1];
            var i = 0;
            while (i < s.Length && s[i] == t[i]) {
                res[i] = s[i];
                ++i;
            }
            while (i < s.Length - 1) 
            {
                res[i] = s[i + 1];
                ++i;
            }
            return new string(res);
        }

        public string SolvePart2For(string[] input)
        {
            for (int i = 0; i < input.Length - 1; ++i) 
            {
                for (int j = i + 1; j < input.Length; ++j) 
                {
                    if (IdsAreGood(input[i], input[j]))
                    {
                        return CommonLetters(input[i], input[j]);
                    }
                }
            }
            return "";
        }
    }

    public enum Repetitions
    {
        None,
        Two,
        Three,
        TwoAndThree
    }
}