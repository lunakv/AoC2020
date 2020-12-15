using Utils;

namespace Exercises.Day_3
{
    public abstract class E5_6 : StringSolver
    {
        protected (int, int) Slope { get; set; } = (3, 1);

        private const char TreeChar = '#';

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