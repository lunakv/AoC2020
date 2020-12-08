using System;
using System.Collections.Generic;

namespace Day_8
{
    public interface IParser
    {
        List<Operation> ParseInput(List<string> input);
    }
    
    public class Parser : IParser
    {
        private readonly Tokenizer _tokenizer = new Tokenizer();
        private readonly OpFactory _factory = new OpFactory();
   
        
        public List<Operation> ParseInput(List<string> input)
        {
            var ret = new List<Operation>();
            foreach (string line in input)
            {
                var split = _tokenizer.Tokenize(line);
                Operation parsed = _factory.Create(split);
                ret.Add(parsed);
            }

            return ret;
        }
        
        
    }
}