using System;
using System.Collections.Generic;
using Utils;

namespace Day_14
{
    public abstract class E27_28 : StringSolver
    {
        protected readonly Dictionary<ulong, ulong> Memory = new Dictionary<ulong, ulong>();
        protected const uint MaskLength = 36;
        
        protected abstract void ParseMask(string mask);
        protected abstract void WriteToMemory(string command, string value);
        public override void Solve()
        {
            foreach (string line in Input)
            {
                var split = line.Split('=');
                if (split[0].StartsWith("mask"))
                {
                    ParseMask(split[1]);
                }
                else
                {
                    WriteToMemory(split[0], split[1]);
                }
            }

            ulong total = 0;
            foreach ((ulong key, ulong val) in Memory)
            {
                total += val;
            }

            Console.WriteLine($"The sum of all memory values is {total}.");
        }
    }
}