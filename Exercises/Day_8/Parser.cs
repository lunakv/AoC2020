using System.Collections.Generic;

namespace Exercises.Day_8
{
    public interface IParser
    {
        List<Operation> ParseInput(List<string> input);
    }
    
    public class Parser : IParser
    {
        private readonly Tokenizer _tokenizer = new();
        private readonly OpFactory _factory = new();
   
        
        public List<Operation> ParseInput(List<string> input)
        {
            var ret = new List<Operation>();
            foreach (string line in input)
            {
                string[] split = _tokenizer.Tokenize(line);
                Operation parsed = _factory.Create(split);
                ret.Add(parsed);
            }

            return ret;
        }
        
        
    }
}