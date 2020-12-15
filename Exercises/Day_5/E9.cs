using System;
using System.Linq;

namespace Exercises.Day_5
{
    public class E9 : E9_10
    {
        public override void Solve()
        {
            int highest = Input.Select(s => GetId(ParseSeat(s))).Max();
            Console.WriteLine($"Highest ID is {highest}");
        }
    }
}