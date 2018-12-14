using System.Text.RegularExpressions;

namespace AdventOfCode2018
{
    public class Day4Solver
    {
        private static readonly string _shiftStartPattern 
            = @"(\[\d{4}-\d{2}-\d{2} \d{2}:(\d{2})\]) ((:?Guard #(\d+) begins shift)|(:?falls asleep)|(:?wakes up))";
        
        public Event Parse(string s)
        {
            var m = Regex.Match(s, _shiftStartPattern);
            if (!m.Success)
            {
                return Event.InvalidInput;
            }

            var e = Event.ShiftStart;
            switch (m.Groups[3].Value)
            {
                case "falls asleep":
                    e = Event.FallenAsleep;
                    break;
                case "wakes up":
                    e = Event.WokeUp;
                    break;
            }

            return e;
        }
    }

    public enum Event
    {
        ShiftStart, FallenAsleep, WokeUp, InvalidInput
    }
}