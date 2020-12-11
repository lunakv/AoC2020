using System;
using System.Linq;
using Utils;

namespace Day_11
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
            char[][] a = Input.Select(s => s.ToCharArray()).ToArray();;
            char[][] b = a.Select(s => new char[s.Length]).ToArray();
            bool current = false; // false for 'a', true for 'b'
            bool changed;
            
            do
            {
                var from = current ? b : a;
                var to = current ? a : b;
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
                    if (from[i][j] == Empty && CountAround(from, i, j) == 0)
                    {
                        to[i][j] = Occupied;
                        changed = true;
                    }
                    else if (from[i][j] == Occupied && CountAround(from, i, j) >= OccupiedNeeded)
                    {
                        to[i][j] = Empty;
                        changed = true;
                    }
                    else
                    {
                        to[i][j] = from[i][j];
                    }
                }
            }

            return changed;
        }
        
        protected int CountOccupied(char[][] seats) => 
            seats.Sum(row => row.Count(seat => seat == Occupied));
    }
}