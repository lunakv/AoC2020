using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Exercises.Day_17
{
    public abstract class Simulator<TVec> : StringSolver
    {
        private const char ActiveChar = '#';
        private const int CycleCount = 6;
        
        protected abstract IEnumerable<TVec> Around(TVec vector);
        protected abstract TVec CreateVector(int i, int j);
        
        public override void Solve()
        {
            var space = ParseInput();
            for (int i = 0; i < CycleCount; i++)
            {
                space = OneStep(space);
            }

            Console.WriteLine($"After {CycleCount} cycles, the space contains {space.Count} active cubes.");
        }

        private HashSet<TVec> ParseInput()
        {
            var space = new HashSet<TVec>();
            
            for (int i = 0; i < Input.Count; i++)
            for (int j = 0; j < Input[i].Length; j++)
            {
                if (Input[i][j] == ActiveChar)
                {
                    space.Add(CreateVector(i, j));
                }
            }

            return space;
        }

        private HashSet<TVec> OneStep(HashSet<TVec> space)
        {
            var ret = new HashSet<TVec>();
            foreach (var vector in space)
            {
                int count = CountAround(vector, space);
                if (count == 2 || count == 3)
                {
                    ret.Add(vector);
                }

                foreach (var around in Around(vector))
                {
                    if (!space.Contains(around) && CountAround(around, space) == 3)
                        ret.Add(around);
                }
            }

            return ret;
        }

        private int CountAround(TVec vector, HashSet<TVec> space) => Around(vector).Count(space.Contains);
    }
}