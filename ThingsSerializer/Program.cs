using RecipeOfMagicalTea;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ThingsSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            var listThings = new List<RepositoryThing>
            {
                new RepositoryThing(0, ThingType.Tea, "Обычный чай", 10, 15),
                new RepositoryThing(1, ThingType.Tea, "Супер-пупер чай", 20, 25),
                new RepositoryThing(2, ThingType.Tea, "Дешевенький чаек", 4, 5)
            };

            XmlSerializer serializerThings = new XmlSerializer(typeof(List<RepositoryThing>));
            FileStream things = new FileStream("Things.xml", FileMode.OpenOrCreate);
            serializerThings.Serialize(things, listThings);
            things.Close();


            var listRecipes = new List<RepositoryRecipe> { new RepositoryRecipe(0, "Обычный чай", 0, new List<ItemNumber<Ingredient>> { new ItemNumber<Ingredient>(5, new Ingredient(IngredientType.TeaLeaves)) }) };
            XmlSerializer serializerRecipes = new XmlSerializer(typeof(List<RepositoryRecipe>));
            FileStream recipes = new FileStream("Recipes.xml", FileMode.OpenOrCreate);
            serializerRecipes.Serialize(recipes, listRecipes);
            recipes.Close();
        }
    }
}
