using System;
using System.Collections;
using System.Collections.Generic;

namespace Day_5
{
    public class E10 : E910
    {
        public override void Solve()
        {
            var ids = GetIdMap();
            for (int i = 1; i < ids.Length - 1; i++)
            {
                if (!ids[i] && ids[i - 1] && ids[i + 1])
                {
                    Console.WriteLine($"Your seat has ID {i}.");
                    return;
                }
            }
        }

        private bool[] GetIdMap()
        {
            bool[] ids = new bool[NumRows * NumCols];
            foreach (string s in Input)
            {
                int id = GetId(ParseSeat(s));
                ids[id] = true;
            }

            return ids;
        }
    }
}