using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Day_18
{
    public class Tokenizer
    {
        public List<string> Tokenize(string input)
        {
            var ret = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '+':
                        ret.Add("+");
                        break;
                    case '*':
                        ret.Add("*");
                        break;
                    case '(':
                        ret.Add("(");
                        break;
                    case ')':
                        ret.Add(")");
                        break;
                    case { } c when char.IsDigit(c):
                        ret.Add(TokenizeNumber(input, ref i));
                        break;
                    case { } c when char.IsWhiteSpace(c):
                        break;
                    default:
                        throw new FormatException($"Unexpected character: '{input[i]}'");
                }
            }

            return ret;
        }

        private string TokenizeNumber(string input, ref int i)
        {
            var sb = new StringBuilder();
            while (i < input.Length && char.IsDigit(input[i]))
            {
                sb.Append(input[i]);
                i++;
            }

            i--;
            return sb.ToString();
        }
    }
}