using System;
using Utils;

namespace Exercises.Day_5
{
    public abstract class E9_10 : StringSolver
    {
        protected const int NumRows = 128;
        protected const int NumCols = 8;
        
        protected (int, int) ParseSeat(string seat)
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
                    default:
                        throw new ArgumentOutOfRangeException(nameof(seat), $"Unknown letter '{c}' found.");
                }
            }

            return (rLow, cLow);
        }

        protected int GetId((int, int) seat) => seat.Item1 * 8 + seat.Item2;
    }
}