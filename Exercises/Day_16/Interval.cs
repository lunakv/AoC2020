using System;
using System.Collections.Generic;

namespace Exercises.Day_16
{
    public class Interval
    {
        public string Name { get; private init; } = "";
        private readonly List<(int, int)> _bounds = new();

        public void AddBounds(int min, int max) => _bounds.Add((min, max));

        public bool Contains(int value)
        {
            foreach ((int min, int max) in _bounds)
            {
                if (value >= min && value <= max)
                    return true;
            }

            return false;
        }

        public static Interval Parse(string name, string values)
        {
            var ret = new Interval {Name = name};

            string[] split = values.Split("or");
            foreach (string interval in split)
            {
                string[] vals = interval.Split('-');
                ret.AddBounds(int.Parse(vals[0]), int.Parse(vals[1]));
            }

            return ret;
        }
    }
}