using System;
using System.Collections.Generic;
using Utils;

namespace Exercises.Day_13
{
    public class E25 : StringSolver
    {
        public override void Solve()
        {
            int startTime = int.Parse(Input[0]);
            var buses = ParseIntervals(Input[1]);
            (int bus, int time) = FindNearestBus(startTime, buses);

            Console.WriteLine($"Nearest bus is {bus} and will arrive in {time} minutes.");
            Console.WriteLine($"The product of these is {bus * time}");
        }

        private List<int> ParseIntervals(string line)
        {
            var ret = new List<int>();
            
            foreach (string interval in line.Split(','))
            {
                if (int.TryParse(interval, out int num))
                {
                    ret.Add(num);
                }
            }

            return ret;
        }

        private (int, int) FindNearestBus(int startTime, List<int> buses)
        {
            if (buses.Count == 0) return (-1, -1);
            
            int nearestBus = buses[0];
            int nearestTime = nearestBus - startTime % nearestBus;

            for (int i = 1; i < buses.Count; i++)
            {
                int bus = buses[i];
                int time = bus - startTime % bus;
                if (time < nearestTime)
                {
                    nearestBus = bus;
                    nearestTime = time;
                }
            }

            return (nearestBus, nearestTime);
        }
    }
}