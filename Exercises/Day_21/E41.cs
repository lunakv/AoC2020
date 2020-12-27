using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace Exercises.Day_21
{
    public class E41 : E41_42
    {
        public override void Solve()
        {
            FoodData data = GetFoodData(ParseInput());
            var possibleAllergens = data.PossibleCauses.Values.SelectMany(x => x);
            var safeFoods = data.Ingredients.Where(x => !possibleAllergens.Contains(x));
            Console.WriteLine($"Safe food count is {safeFoods.Sum(f => data.IngredientCounts[f])}");
        }
    }
}