using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Day_5
{
    public class E9 : StringSolver
    {
        private const int NumRows = 128;
        private const int NumCols = 8;
        public override void Solve()
        {
            int highest = Input.Select(s => GetId(ParseSeat(s))).Max();
            Console.WriteLine($"Highest ID is {highest}");
        }

        private (int, int) ParseSeat(string seat)
        {
            int rLow = 0;
            int rHigh = NumRows;
            int cLow = 0;
            int cHigh = NumCols;

            foreach (char c in seat)
            {
                int rDiff = rHigh - rLow;
                int cDiff = cHigh - cLow;

                switch (c)
                {
                    case 'F':
                        rHigh -= rDiff / 2;
                        break;
                    case 'B':
                        rLow += rDiff / 2;
                        break;
                    case 'L':
                        cHigh -= cDiff / 2;
                        break;
                    case 'R':
                        cLow += cDiff / 2;
                        break;
                }
            }

            return (rLow, cLow);
        }

        private int GetId((int, int) seat) => seat.Item1 * 8 + seat.Item2;
    }
}