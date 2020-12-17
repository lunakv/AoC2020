using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises.Day_16
{
    public class E32 : E31_32
    {
        private readonly List<HashSet<Interval>> _possible = new();
        public override void Solve()
        {
            // parse input
            ParseInput();
            PruneInvalidTickets();
            for (int pos = 0; pos < MyTicket.Count; pos++)
            {
                _possible.Add(Fields.ToHashSet());
            }

            // delete intervals from impossible positions
            foreach (var ticket in NearbyTickets)
            {
                int i = 0;
                foreach (int field in ticket)
                {
                    PrunePosition(i++, field);
                }
            }

            // delete unique intervals from other positions
            var unique = UniqueIntervals();
            while (PruneUniquePositions(unique))
            {
                unique = UniqueIntervals();
            }

            // enumerate what's left
            long total = 1;
            for (int i = 0; i < _possible.Count; i++)
            {
                // position doesn't have a unique associated field
                if (_possible[i].Count != 1)
                {
                    Console.Error.WriteLine($"Multiple possibilities at position {i} ({_possible[i].Count}).");
                    foreach (Interval inter in _possible[i])
                    {
                        Console.Error.WriteLine($"\tPossibility: {inter}");
                    }
                    return;
                }

                Interval option = _possible[i].First();
                if (option.Name.StartsWith("departure"))
                {
                    Console.WriteLine($"Field '{option.Name}' at position {i} has value {MyTicket[i]}");
                    total *= MyTicket[i];
                }
            }

            Console.WriteLine($"\nTotal of 'departure' fields is {total}");
        }

        private void PruneInvalidTickets()
        {
            NearbyTickets = NearbyTickets.Where(IsPossibleTicket).ToList();
        }

        private void PrunePosition(int i, int field)
        {
            _possible[i].RemoveWhere(interval => !interval.Contains(field));
        }

        private bool PruneUniquePositions(List<Interval> unique)
        {
            bool changed = false;
            foreach (var set in _possible)
            {
                if (set.Count != 1)
                {
                    changed |= set.RemoveWhere(unique.Contains) > 0;
                }
            }

            return changed;
        }

        private List<Interval> UniqueIntervals() =>
            _possible.Where(set => set.Count == 1).Select(set => set.First()).ToList();
    }
}