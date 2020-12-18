using System;
using System.Collections.Generic;
using Utils;

namespace Exercises.Day_18
{
    public interface IParser
    {
        Expression? Parse(List<string> tokens);
    }
    
    public abstract class E35_36<T> : StringSolver where T : IParser, new()
    {
        public override void Solve()
        {
            long total = 0;
            foreach (string line in Input)
            {
                Expression? ast = new T().Parse(new Tokenizer().Tokenize(line));
                if (ast is null)
                {
                    Console.WriteLine("AST is null");
                    Console.WriteLine($"  Expression: '{line}'");
                }
                else
                {
                    /*
                    Console.WriteLine(line);
                    Console.WriteLine(ast.Print());
                    Console.WriteLine(ast.Resolve());
                    /**/
                    total += ast.Resolve();
                }
            }

            Console.WriteLine($"Sum of expressions is {total}");
        }
    }
    
    public class E35 : E35_36<LtrParser> { }
    public class E36 : E35_36<MultPrecedenceParser> { }
}