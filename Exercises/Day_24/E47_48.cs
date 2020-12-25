using System.Collections.Generic;
using Utils;

namespace Exercises.Day_24
{
    public abstract class E47_48 : StringSolver
    {
        protected Dictionary<(int, int), int> ParseInput()
        {
            var flips = new Dictionary<(int, int), int>();
            foreach (string line in Input)
            {
                char buffer = '\0';
                int x = 0;
                int y = 0;
                foreach (char c in line)
                {
                    (x, y) = c switch
                    {
                        'e' when buffer == 'n' => (x + 1, y + 1),
                        'e' when buffer == 's' => (x - 1, y),
                        'w' when buffer == 'n' => (x + 1, y),
                        'w' when buffer == 's' => (x - 1, y - 1),
                        'e' => (x, y + 1),
                        'w' => (x, y - 1),
                        _ => (x, y),
                    };

                    buffer = (c == 'n' || c == 's') ? c : '\0';
                }

                flips.TryAdd((x, y), 0);
                flips[(x, y)]++;
            }

            return flips;
        }
    }
}