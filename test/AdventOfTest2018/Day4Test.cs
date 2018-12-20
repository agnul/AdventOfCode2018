using System;
using Xunit;
using AdventOfCode2018;

namespace AdventOfTest2018
{
    public class Day4Test
    {
        private readonly Day4Solver _day4 = new Day4Solver();

        [Fact]
        public void ItCanParseAShiftStart()
        {
            const string s = "[1518-11-01 00:00] Guard #10 begins shift";

            Assert.Equal(Event.GuardStartsShift("[1518-11-01 00:00]", 10), _day4.Parse(s));
        }

        [Fact]
        public void ItCanParseAFallAsleepEvent()
        {
            const string s = "[1518-11-01 00:05] falls asleep";

            Assert.Equal(Event.GuardFallsAsleep("[1518-11-01 00:05]"), _day4.Parse(s));
        }

        [Fact]
        public void ItCanParseAWakeUpEvent()
        {
            const string s = "[1518-11-01 00:05] wakes up";

            Assert.Equal(Event.GuardWakesUp("[1518-11-01 00:05]"), _day4.Parse(s));
        }

        [Fact]
        public void EveryThingElseIsInvalid()
        {
            const string s = "[1518-11-01 00:05] whatever";

            Assert.Throws<ArgumentException>(() => _day4.Parse(s));
        }

        [Fact]
        public void ItCreatesAGuard()
        {
            var d = new DutyRoster();
            var s = Event.GuardStartsShift("[1518-11-01 00:05]", 10);

            d.OnEvent((ShiftStartEvent) s);

            Assert.Equal(new Guard(10), d.GuardOnDuty);
        }
    }

}
