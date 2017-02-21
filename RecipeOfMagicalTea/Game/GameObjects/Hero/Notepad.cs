using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    public class Notepad
    {
        public List<Recipe> Recipes;
        public List<string> Dilogs;

        public Notepad()
        {
            Recipes = new List<Recipe>();
            Dilogs = new List<string>();
        }

        public void Add(Recipe recipe)
        {
            Recipes.Add(recipe);
        }
    }
}
