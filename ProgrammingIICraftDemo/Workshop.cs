using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingIICraftDemo
{
    internal class Workshop
    {
        List<Recipe> Recipes = new List<Recipe>();
        Player player = new Player() {Inventory = new List<Item> 
        { 
            new Item() {Name="Chocolate", Amount = 3, AmountType = "pound(s)"},
            new Item() {Name="Water", Amount = 10, AmountType = "cup(s)"}
             } };
        Person vendor = new Person();

        public Workshop()
        {
          SetPlayerName("Anonymous Player");
            Recipes.Add(
                new Recipe()
                {
                    Name = "Powdered Sugar Icing",
                    Description = "Tasty icing that can be used with many recipes.",
                    Requirements = new List<Item>()
                    {
                        new Item(){Name = "Powdered Sugar", Amount = 1, AmountType="cup" },
                        new Item(){Name = "Vanilla Extract", Amount = 1.5, AmountType="tsp" },
                        new Item(){Name = "Milk", Amount = 2, AmountType="tbsp" }
                    },

                }
                ) ;
        }
        public string CreateNewItem()
        {
            return "\nCreate new item is not yet functional\n";
        }
        public string Trade()
        {
            return "\nTrade is not yet functional.\n";
        }
        public string ShowRecipes()
        {
            string output = "Recipes:\n";
            foreach (Recipe r in Recipes)
            {
                output += $"  * {r.ShowRecipeDetails()}\n";
            }
            return output;
        }
        //ShowPlayerInventory looks a lot like ShowRecipes
        //Can you refactor so that there is less redundent code?
        public string ShowPlayerInventory()
        {
            string output = $"Current inventory:\n";
            foreach (Item i in player.Inventory)
            {
                output += $"  * {i.Name} ({i.Amount})\n";
            }
            return output;
        }

        public string ShowPlayerName() => player.Name;
        public string ShowPlayerNameAndCurrency() => $"{player.Name} {player.Currency.ToString("c")}";
        public void SetPlayerName(string name) { player.Name = name; }

    }
}
