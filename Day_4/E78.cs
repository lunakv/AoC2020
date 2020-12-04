using System;
using System.Collections.Generic;
using Utils;

namespace Day_4
{
    public abstract class E78 : StringSolver
    {
        protected readonly HashSet<string> Required = new HashSet<string>
            {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};
        
        protected List<Dictionary<string, string>> GetPassports()
        {
            var ret = new List<Dictionary<string, string>>();
            var curr = new Dictionary<string, string>();
            foreach (string line in Input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    ret.Add(curr);
                    curr = new Dictionary<string, string>();
                }
                else
                {
                    var fields = line.Split(' ');
                    foreach (string field in fields)
                    {
                        var split = field.Split(':');
                        if (split.Length < 2) 
                            throw new FormatException($"Field {field} has an invalid format.");
                        if (Required.Contains(split[0])) 
                            curr.TryAdd(split[0], split[1]);
                    }
                }
            }
            
            if (curr.Count != 0) ret.Add(curr);
            return ret;
        }
    }
}