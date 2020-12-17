using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Utils;

namespace Exercises.Day_16
{
    public class E31 : E31_32
    {
        private readonly Dictionary<string, Interval> _fields = new();
        public override void Solve()
        {
            ParseInput();
            int total = 0;
            foreach (var ticket in NearbyTickets)
            {
                total += ticket.Where(x => !IsPossibleField(x)).Sum();
            }

            Console.WriteLine($"Invalid total is {total}.");
        }

        


    }
}