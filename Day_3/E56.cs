using System.Collections.Generic;
using Utils;

namespace Day_3
{
    public abstract class E56 : StringSolver
    {
        public (int, int) Slope { get; set; }

        public char TreeChar { get; set; } = '#';
        
        protected uint CountTrees()
        {
            uint trees = 0;
            int width = Input[0].Length;
            int x = 0;
            for (int y = 0; y < Input.Count; y += Slope.Item2)
            {
                if (Input[y][x] == TreeChar) trees++;
                x = (x + Slope.Item1) % width;
            }

            return trees;
        }
    }
}