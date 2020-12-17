using System.Collections.Generic;

namespace Exercises.Day_17
{
    public static class Arounder
    {
        public static IEnumerable<(int, int, int, int)> Around4D((int, int, int, int) vector)
        {
            (int x, int y, int z, int w) = vector;
            for (int i = -1; i <= 1; i++) 
            for (int j = -1; j <= 1; j++)
            for (int k = -1; k <= 1; k++)
            for (int l = -1; l <= 1; l++)
                if ((i, j, k, l) != (0, 0, 0, 0))
                    yield return (x + i, y + j, z + k, w + l);
        }

        public static IEnumerable<(int, int, int)> Around3D((int, int, int) vector)
        {
            (int x, int y, int z) = vector;
            for (int i = -1; i <= 1; i++) 
            for (int j = -1; j <= 1; j++)
            for (int k = -1; k <= 1; k++)
                if ((i, j, k) != (0, 0, 0))
                    yield return (x + i, y + j, z + k);
        }
    }
}