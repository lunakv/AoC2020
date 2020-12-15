using System.Linq;
using Utils;

namespace Exercises.Day_11
{
    public abstract class E21_22 : StringSolver
    {
        protected const char Occupied = '#';
        protected const char Empty = 'L';
        protected const char Floor = '.';

        protected abstract int CountAround(char[][] from, int i, int j);

        protected abstract int OccupiedNeeded { get; }
        
        protected char[][] Run()
        {
            char[][] a = Input.Select(s => s.ToCharArray()).ToArray();
            char[][] b = a.Select(s => new char[s.Length]).ToArray();
            bool current = false; // false for 'a', true for 'b'
            bool changed;
            
            do
            {
                char[][] from = current ? b : a;
                char[][] to = current ? a : b;
                changed = OneStep(from, to);
                current = !current;
            } while (changed);

            return current ? b : a;
        }
        
        private bool OneStep(char[][] from, char[][] to)
        {
            bool changed = false;
            for (int i = 0; i < from.Length; i++)
            {
                for (int j = 0; j < from[i].Length; j++)
                {
                    switch (from[i][j])
                    {
                        case Empty when CountAround(from, i, j) == 0:
                            to[i][j] = Occupied;
                            changed = true;
                            break;
                        case Occupied when CountAround(from, i, j) >= OccupiedNeeded:
                            to[i][j] = Empty;
                            changed = true;
                            break;
                        default:
                            to[i][j] = from[i][j];
                            break;
                    }
                }
            }

            return changed;
        }
        
        protected int CountOccupied(char[][] seats) => 
            seats.Sum(row => row.Count(seat => seat == Occupied));
    }
}