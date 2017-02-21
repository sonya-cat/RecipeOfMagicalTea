using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    [Serializable]
    public class RepositoryIngredientObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxIngridientNumber { get; set; }
        public ItemNumber<Ingredient> Ingredient { get; set; }

        public RepositoryIngredientObject()
        {
        }

        public RepositoryIngredientObject(int id, string name, int maxIngridientNumber, ItemNumber<Ingredient> ingredient)
        {
            Id = id;
            Name = name;
            MaxIngridientNumber = maxIngridientNumber;
            Ingredient = ingredient;
        }

    }
}