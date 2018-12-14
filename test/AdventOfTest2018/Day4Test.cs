using AdventOfCode2018;
using Xunit;

namespace AdventOfTest2018
{
    public class Day4Test
    {
        private readonly Day4Solver _day4 = new Day4Solver();
        
        [Fact]
        public void ItCanParseAShiftStart()
        {
            const string s = "[1518-11-01 00:00] Guard #10 begins shift";

            Assert.Equal(Event.ShiftStart, _day4.Parse(s));
        }

        [Fact]
        public void ItCanParseAFallAsleepEvent()
        {
            const string s = "[1518-11-01 00:05] falls asleep";
            
            Assert.Equal(Event.FallenAsleep, _day4.Parse(s));
        }

        [Fact]
        public void ItCanParseAWakeUpEvent()
        {
            const string s = "[1518-11-01 00:05] wakes up";
            
            Assert.Equal(Event.WokeUp, _day4.Parse(s));
        }

        [Fact]
        public void EveryThingElseIsInvalid()
        {
            const string s = "[1518-11-01 00:05] whatever";

            Assert.Equal(Event.InvalidInput, _day4.Parse(s));
        }
    }

}