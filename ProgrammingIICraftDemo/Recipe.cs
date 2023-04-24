using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingIICraftDemo
{
    internal class Recipe
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Item> Requirements { get; set; }

        //example using StringBuilder instead of string interpolation
        public string ShowRecipeDetails()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"{Name}: {Description}")
                  .AppendLine("     Ingredients:");

            int number = 1;
            foreach (var ingredient in Requirements)
            {
                output.AppendLine($"       {number}) {ingredient.Amount} {ingredient.AmountType} of {ingredient.Name}");
                number++;
            }

            return output.ToString();
        }

    }
}
