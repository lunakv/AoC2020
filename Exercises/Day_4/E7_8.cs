using System;
using System.Collections.Generic;
using Utils;

namespace Exercises.Day_4
{
    public abstract class E7_8 : StringSolver
    {
        protected readonly HashSet<string> Required = new() {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};
        
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
                    string[] fields = line.Split(' ');
                    foreach (string field in fields)
                    {
                        string[] split = field.Split(':');
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