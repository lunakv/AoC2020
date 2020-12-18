using System;
using System.Collections.Generic;

namespace Exercises.Day_18
{
    public class LtrParser : IParser
    {
        public Expression? Parse(List<string> tokens)
        {
            int start = 0;
            return ParseExpression(tokens, ref start, tokens.Count);
        }

        private Expression? ParseExpression(List<string> tokens, ref int start, int end, bool parenthesized = false)
        {
            Expression? e = ParseSimpleExpression(tokens, ref start, end);
            if (e is null || start == end) return e;
            while (start < end)
            {
                if (parenthesized && tokens[start] == ")") return e;
                Expression? next = ParseBinaryExpression(tokens, ref start, end, e);
                if (next is null) return null;
                e = next;
            }

            return e;
        }

        private Expression? ParseSimpleExpression(List<string> tokens, ref int start, int end)
        {
            if (start == end) return null;
            switch (tokens[start])
            {
                case { } i when int.TryParse(i, out int value):
                    var val = new ValueExpression(value);
                    start++;
                    return val;
                case "(":
                    int originalStart = start;
                    start++;
                    var paren = ParseExpression(tokens, ref start, end, true);
                    if (paren is null || start == end || tokens[start] != ")")
                    {
                        start = originalStart;
                        return null;
                    }

                    start++;
                    return paren;
                default:
                    return null;
            }
        }

        private Expression? ParseBinaryExpression(List<string> tokens, ref int start, int end, Expression? left)
        {
            if (left is null) return null;
            string token = tokens[start];
            if (token != "*" && token != "+") return left;
            
            start++;
            Expression? right = ParseSimpleExpression(tokens, ref start, end);
            if (right is null)
            {
                start--;
                return null;
            }

            return token switch
            {
                "+" => new AddExpression(left, right),
                "*" => new MultExpression(left, right),
                _ => throw new Exception("This can never be reached"),
            };
        }
    }
}