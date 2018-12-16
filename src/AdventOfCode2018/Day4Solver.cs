using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2018
{
    public class Day4Solver
    {
        private static readonly string _shiftStartPattern 
            = @"(\[\d{4}-\d{2}-\d{2} \d{2}:(\d{2})\]) ((?:Guard #(\d+) begins shift)|(?:falls asleep)|(?:wakes up))";
        
        public Event Parse(string s)
        {
            var m = Regex.Match(s, _shiftStartPattern);
            if (!m.Success)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i <= m.Groups.Count; ++i)
            {
                Console.Error.WriteLine($"Group {i} is {m.Groups[i].Value}");
            }

            Event e = null;
            switch (m.Groups[3].Value)
            {
                case "falls asleep":
                    e = Event.GuardFallsAsleep(m.Groups[1].Value);
                    break;
                case "wakes up":
                    e = Event.GuardWakesUp(m.Groups[1].Value);
                    break;
                default:
                    e = Event.GuardStartsShift(
                        m.Groups[1].Value, int.Parse(m.Groups[4].Value));
                    break;
            }

            return e;
        }
    }

    public abstract class Event
    {
        public string EventDate {  get => _eventDate; }

        protected readonly string _eventDate;

        public static Event GuardStartsShift(string date, int id)
        {
            return new ShiftStartEvent(date, id);
        }

        public static Event GuardFallsAsleep(string date)
        {
            return new GuardFallsAsleepEvent(date);
        }

        public static Event GuardWakesUp(string date)
        {
            return new GuardWakesUpEvent(date);
        }

        protected Event(string date) 
        {
            _eventDate = date;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                
                hash = hash * 23 + _eventDate.GetHashCode();

                return hash;
            }
        }
    }

    public class ShiftStartEvent: Event
    {
        private readonly int _id;

        public int ID { get => _id; }

        protected internal ShiftStartEvent(string date, int id) : base(date) { 
            _id = id;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            ShiftStartEvent e = (ShiftStartEvent) obj;
            return _eventDate.Equals(e._eventDate) && _id == e._id;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                
                hash = hash * 23 + base.GetHashCode();

                return hash;
            }
        }
    }

    public class GuardFallsAsleepEvent: Event
    {
        protected internal GuardFallsAsleepEvent(string date) : base(date) { }

        public override bool Equals(object obj)
        {
            if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            GuardFallsAsleepEvent e = (GuardFallsAsleepEvent) obj;
            return _eventDate.Equals(e._eventDate);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                
                hash = hash * 23 + base.GetHashCode();

                return hash;
            }
        }
    }

    public class GuardWakesUpEvent: Event
    {
        protected internal GuardWakesUpEvent(string date) : base(date) { }

        public override bool Equals(object obj)
        {
            if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            GuardWakesUpEvent e = (GuardWakesUpEvent) obj;
            return _eventDate.Equals(e._eventDate);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                
                hash = hash * 23 + base.GetHashCode();

                return hash;
            }
        }
    }

    public class Guard
    {
        private readonly int _ID;

        public int ID { get => _ID; }

        public Guard(int id)
        {
            _ID = id;
        }
 
        public override bool Equals(object obj)
        {
            if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            Guard g = (Guard) obj;
            return _ID.Equals(g._ID);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                
                hash = hash * 23 + _ID.GetHashCode();

                return hash;
            }
        }
    }

    public class DutyRoster
    {
        public Guard GuardOnDuty { get => _roster[_onDuty]; }

        private Dictionary<int, Guard> _roster = new Dictionary<int, Guard>();

        private int _onDuty;

        public void onEvent(ShiftStartEvent e)
        {
            _onDuty = e.ID;

            Guard g;
            if ( ! _roster.ContainsKey(_onDuty) )
            {
                g = new Guard(_onDuty);
                _roster.Add(_onDuty, g);
            }
            else 
            {
                g = _roster[_onDuty];
            }
        }
    }
}