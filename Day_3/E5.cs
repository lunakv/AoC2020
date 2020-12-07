using System;

namespace Day_3
{
    public class E5 : E5_6
    {
        public override void Solve()
        {
            uint trees = CountTrees();
            Console.WriteLine($"This path would encounter {trees} trees.");
        }
    }
}