using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace Exercises.Day_21
{
    public class E42 : E41_42
    {
        public override void Solve()
        {
            FoodData data = GetFoodData(ParseInput());
            PruneAllergens(data.PossibleCauses);

            var sb = new StringBuilder();
            // list dangerous ingredients in alphabetical order of allergen
            foreach (string allergen in data.Allergens.ToImmutableSortedSet())
            {
                var causes = data.PossibleCauses[allergen];
                if (causes.Count != 1) throw new Exception($"'{allergen}' isn't uniquely identifiable ({causes.Count})");
                sb.Append(causes.First());
                sb.Append(',');
            }
            
            // remove last ','
            sb.Remove(sb.Length - 1, 1);
            Console.WriteLine("Canonical list of dangerous ingredients:");
            Console.WriteLine(sb.ToString());
        }
        
        private void PruneAllergens(Dictionary<string, HashSet<string>> possibleCauses)
        {
            bool changed;
            do
            {
                changed = false;
                foreach ((string key, var value) in possibleCauses)
                {
                    if (value.Count != 1) continue;
                    string identified = value.First();
                    foreach ((string k, var v) in possibleCauses)
                    {
                        if (k != key) changed |= v.Remove(identified);
                    }
                }
            } while (changed);
        }
    }
}