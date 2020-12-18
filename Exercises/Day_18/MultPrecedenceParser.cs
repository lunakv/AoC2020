using System.Collections.Generic;

namespace Exercises.Day_18
{
    public class MultPrecedenceParser : IParser
    {
        public Expression? Parse(List<string> tokens)
        {
            int start = 0;
            Expression? e = ParseExpression(tokens, ref start, tokens.Count);
            return start == tokens.Count ? e : null;
        }

        private Expression? ParseExpression(List<string> tokens, ref int start, int end)
        {
            return ParseMultExpression(tokens, ref start, end);
        }

        private Expression? ParseMultExpression(List<string> tokens, ref int start, int end)
        {
            Expression? left = ParseAddExpression(tokens, ref start, end);
            if (left is null || start == end) return left;
            if (tokens[start] != "*") return left;
            start++;
            Expression? right = ParseMultExpression(tokens, ref start, end);
            if (right is null)
            {
                start--;
                return left;
            }

            return new MultExpression(left, right);
        }

        private Expression? ParseAddExpression(List<string> tokens, ref int start, int end)
        {
            Expression? left = ParseSimpleExpression(tokens, ref start, end);
            if (left is null || start == end) return left;
            if (tokens[start] != "+") return left;
            start++;
            Expression? right = ParseAddExpression(tokens, ref start, end);
            if (right is null)
            {
                start--;
                return left;
            }

            return new AddExpression(left, right);
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
                    var paren = ParseExpression(tokens, ref start, end);
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
    }
}