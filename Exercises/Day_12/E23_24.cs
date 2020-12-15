using System;
using Utils;

namespace Exercises.Day_12
{
    internal enum Direction
    {
        N,
        E,
        S,
        W,
    }
    
    public abstract class E23_24 : StringSolver
    {
        protected (char, int) ParseInstruction(string line)
        {
            char i = line[0];
            string argStr = line.Substring(1);
            if (int.TryParse(argStr, out int arg))
            {
                return (i, arg);
            }
            
            throw new Exception($"Couldn't convert {argStr} to an integer argument");
        }

        protected int ManhattanDistance((int, int) vector) =>
            Math.Abs(vector.Item1) + Math.Abs(vector.Item2);
    }
}