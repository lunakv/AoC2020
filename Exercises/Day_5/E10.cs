using System;

namespace Exercises.Day_5
{
    public class E10 : E9_10
    {
        public override void Solve()
        {
            bool[] ids = GetIdMap();
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