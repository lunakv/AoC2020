using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day_4
{
    public class E8 : E78
    {
        private static readonly Dictionary<string,Predicate<string>> Formats = new Dictionary<string, Predicate<string>>
        {
            {"byr", val => int.TryParse(val, out int n) && n >= 1920 && n <= 2002},
            {"iyr", val => int.TryParse(val, out int n) && n >= 2010 && n <= 2020},
            {"eyr", val => int.TryParse(val, out int n) && n >= 2020 && n <= 2030},
            {"hgt", val =>
            {
                if (val.Length < 2) return false;
                string unit = val.Substring(val.Length - 2);
                string num = val.Substring(0, val.Length - 2);
                return unit switch
                {
                    "cm" => int.TryParse(num, out int n) && n >= 150 && n <= 193,
                    "in" => int.TryParse(num, out int n) && n >= 59 && n <= 76,
                    _ => false
                };
            }},
            {"hcl", val => Regex.IsMatch(val, "^#[0-9a-f]{6}$")},
            {"ecl", val =>
            {
                var s = new [] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
                return s.Contains(val);
            }},
            {"pid", val => Regex.IsMatch(val, "^[0-9]{9}$")}
        };
        
        public override void Solve()
        {
            var passports = GetPassports();
            int valid = passports.Count(passport => Required.SetEquals(passport.Keys) && IsValidFormat(passport));

            Console.WriteLine($"Found {valid} valid properly formatted passports.");
        }

        private bool IsValidFormat(Dictionary<string, string> passport)
        {
            foreach ((string key, string value) in passport)
            {
                if (!Formats[key](value))
                    return false;
            }

            return true;
        }
    }
}