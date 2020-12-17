using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Exercises.Day_16
{
    public abstract class E31_32 : StringSolver
    {
        protected readonly List<Interval> Fields = new();
        protected List<int> MyTicket = new();
        protected List<IEnumerable<int>> NearbyTickets = new();

        protected void ParseInput()
        {
            int i = 0;
            ParseFields(ref i);
            ParseMyTicket(ref i);
            ParseNearbyTickets(ref i);
        }

        private void ParseFields(ref int i)
        {
            for (; i < Input.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(Input[i]))
                {
                    i++;
                    return;
                }

                string[] split = Input[i].Split(':');
                Fields.Add(Interval.Parse(split[0], split[1]));
            }
        }

        private void ParseMyTicket(ref int i)
        {
            MyTicket = Input[++i].Split(',').Select(int.Parse).ToList();
            i += 2;
        }

        private void ParseNearbyTickets(ref int i)
        {
            for (i++; i < Input.Count; i++)
            {
                NearbyTickets.Add(Input[i].Split(',').Select(int.Parse));
            }
        }

        protected bool IsPossibleField(int field) => Fields.Any(value => value.Contains(field));

        protected bool IsPossibleTicket(IEnumerable<int> ticket) => ticket.All(IsPossibleField);
    }
}