using System;

namespace Exercises.Day_8
{
    public class Tokenizer
    {
        public string[] Tokenize(string line)
        {
            return line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}