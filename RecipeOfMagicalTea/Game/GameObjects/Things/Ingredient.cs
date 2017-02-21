using System;

namespace RecipeOfMagicalTea
{
    [Serializable]
    public class Ingredient
    {
        public IngredientType Type { get; set; }

        public Ingredient()
        {
        }

        public Ingredient(IngredientType type)
        {
            Type = type;
        }
    }
}