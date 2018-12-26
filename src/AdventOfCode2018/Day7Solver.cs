using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2018
{
    public struct Step
    {
        public readonly char Id;

        public readonly SortedSet<char> Predecessors;

        public Step(char id)
        {
            Id = id;
            Predecessors = new SortedSet<char>();
        }

        public Step(char id, SortedSet<char> predecessors) : this(id)
        {
            foreach (var p in predecessors)
            {
                Predecessors.Add(p);
            }
        }

        public void AddPredecessor(char p)
        {
            Predecessors.Add(p);
        }

        public void RemovePredecessor(char p)
        {
            if (Predecessors.Contains(p))
            {
                Predecessors.Remove(p);
            }
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;

                hash = hash * 23 + Id.GetHashCode();
                foreach (var p in Predecessors)
                {
                    hash = hash * 23 + p.GetHashCode();
                }

                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var that = (Step) obj;
            return Id == that.Id && Predecessors.SetEquals(that.Predecessors);
        }

        public override string ToString()
        {
            return $"{Id} <- {string.Join(", ", Predecessors)}";
        }
    }

    public class Day7Solver
    {
        private const string _rulePattern = @"Step ([A-Z]) must be finished before step ([A-Z]) can begin.";

        public SortedDictionary<char, Step> Steps { get; } = new SortedDictionary<char, Step>();

        public void AddRule(string r)
        {
            var match = Regex.Match(r, _rulePattern);
            if (!match.Success)
            {
                throw new ArgumentException($"Invalid rule {r}");
            }

            var before = new Step(match.Groups[1].Value[0]);
            var after = new Step(match.Groups[2].Value[0]);

            if (!Steps.ContainsKey(before.Id))
            {
                Steps.Add(before.Id, before);
            }

            if (!Steps.ContainsKey(after.Id))
            {
                Steps.Add(after.Id, after);
            }

            Steps[after.Id].AddPredecessor(before.Id);
        }

        public string ExecutionPlan()
        {
            var b = new StringBuilder();
            while (Steps.Count != 0)
            {
                var (key, _) = Steps
                    .First(s => s.Value.Predecessors.Count == Steps.Min(y => y.Value.Predecessors.Count));

                foreach (var dependent in Steps.Where(s => s.Key != key))
                {
                    dependent.Value.RemovePredecessor(key);
                }

                Steps.Remove(key);
                b.Append(key);
            }
            return b.ToString();
        }

        public string SolvePart1For(string[] rules)
        {
            foreach (var r in rules)
            {
                AddRule(r);
            }

            return ExecutionPlan();
        }
    }
}
