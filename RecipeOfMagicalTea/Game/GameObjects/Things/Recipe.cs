using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    [Serializable]
    public class Recipe
    {
        public string Name { get; set; }
        public List<ItemNumber<Ingredient>> Ingredients { get; set; }
        public int ThingEffect { get; set; }
        public int ThingCost { get; set; }

        public Recipe()
        {
        }

        public Recipe(string name, int thingEffect, int thingCost, List<ItemNumber<Ingredient>> ingredients)
        {
            Name = name;
            ThingEffect = thingEffect;
            Ingredients = ingredients;
            ThingCost = thingCost;
        }      
    }
}
