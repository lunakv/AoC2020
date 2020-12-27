using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Exercises.Day_21
{
    public abstract class E41_42 : StringSolver
    {
        protected List<(string[], string[])> ParseInput()
        {
            var ret = new List<(string[], string[])>();
            foreach (string line in Input)
            {
                string[] split = line.Split(new[] {"(contains ", ")"}, StringSplitOptions.RemoveEmptyEntries);
                string foods = split[0];
                string allergens = split[1];
                string[] foodList = foods.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string[] allergenList = allergens.Split(", ");
                ret.Add((foodList, allergenList));
            }

            return ret;
        }

        protected FoodData GetFoodData(List<(string[], string[])> parsedInput)
        {
            var foodCounts = new Dictionary<string, int>();
            var foodList = new HashSet<string>();
            var allergenList = new HashSet<string>();
            var possibleCauses = new Dictionary<string, HashSet<string>>();
            
            // fill in data
            foreach ((string[] foods, string[] allergens) in parsedInput)
            {
                foreach (string allergen in allergens)
                {
                    if (!possibleCauses.ContainsKey(allergen))
                    {
                        possibleCauses[allergen] = new HashSet<string>(foods);
                    }
                    else
                    {
                        possibleCauses[allergen].RemoveWhere(f => !foods.Contains(f));
                    }

                    allergenList.Add(allergen);
                }

                //Print(possibleCauses);
                foreach (string food in foods)
                {
                    foodCounts.TryAdd(food, 0);
                    foodCounts[food]++;
                    foodList.Add(food);
                }
            }

            return new FoodData
            {
                Allergens = allergenList, Ingredients = foodList, IngredientCounts = foodCounts,
                PossibleCauses = possibleCauses,
            };
        }
    }

    public record FoodData
    {
        public HashSet<string> Allergens { get; init; } = new();
        public HashSet<string> Ingredients { get; init; } = new();
        public Dictionary<string, int> IngredientCounts { get; init; } = new();
        public Dictionary<string, HashSet<string>> PossibleCauses { get; init; } = new();
    }
}