using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Day_4
{
    public class E7 : StringSolver
    {
        private readonly HashSet<string> _required = new HashSet<string> 
            {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};

        public override void Solve()
        {
            var valid = 0;
            var passport = new HashSet<string>();
            foreach (string line in Input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    if (passport.SetEquals(_required))
                    {
                        valid++;
                    }
                    passport = new HashSet<string>();
                }
                else
                {
                    var fields = line.Split(' ').Select(x => x.Split(':')[0]);
                    foreach (var field in fields)
                    {
                        if (_required.Contains(field))
                        {
                            passport.Add(field);
                        }
                    }
                }
            }

            if (passport.SetEquals(_required)) valid++;
            Console.WriteLine($"Found {valid} valid passports.");
        }
    }
}