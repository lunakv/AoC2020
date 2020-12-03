using System;
using System.Collections.Generic;
using Utils;

namespace Day_3
{
    public class E5 : E56
    {
        public override void Solve()
        {
            uint trees = CountTrees();
            Console.WriteLine($"This path would encounter {trees} trees.");
        }
        
        
    }
}