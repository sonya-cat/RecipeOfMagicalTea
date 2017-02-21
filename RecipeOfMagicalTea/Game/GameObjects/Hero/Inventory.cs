using RecipeOfMagicalTea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    public class Inventory
    {
        public List<ItemNumber<Thing>> Things;
        public List<ItemNumber<Ingredient>> Ingredients;

        public Inventory ()
        {
            Things = new List<ItemNumber<Thing>>();
            Ingredients = new List<ItemNumber<Ingredient>>() { new ItemNumber<Ingredient>(0, new Ingredient(IngredientType.TeaLeaves)) };
        }

        public void Add(ItemNumber<Thing> thingItem)
        {
            if (Things.Any(t => t.Item.Name == thingItem.Item.Name))
                Things.Find(t => t.Item.Name == thingItem.Item.Name).Number += thingItem.Number;
            else
                Things.Add(new ItemNumber<Thing>(thingItem.Number, thingItem.Item));
        }

        public void Add(ItemNumber<Ingredient> ingredientItem)
        {
            if (Ingredients.Any(t => t.Item.Type == ingredientItem.Item.Type))
                Ingredients.Find(t => t.Item.Type == ingredientItem.Item.Type).Number += ingredientItem.Number;
            else
                Ingredients.Add(ingredientItem);
        }

        public void DeleteThing(int id, int number = 1)
        {
            Things[id].Number -= number;
            if (Things[id].Number <= 0)
                Things.RemoveAt(id);
        }

        public void DeleteThing(string name, int number = 1)
        {
            var thing = Things.FirstOrDefault(t => t.Item.Name == name);
            if (thing != null)
                DeleteThing(Things.IndexOf(thing));
        }

        public ItemNumber<Ingredient> GetIngredient(IngredientType type)
        {
            return Ingredients.Find(t => t.Item.Type == type);
        }

        public int GetIngredientId(IngredientType type)
        {
            return Ingredients.IndexOf(GetIngredient(type));
        }

        public bool CheckIngredients(List<ItemNumber<Ingredient>> ingredients)
        {
            return ingredients.All(t => Ingredients.Any(c => c.Item.Type == t.Item.Type && c.Number >= t.Number));
        }

        public void DeleteIngredient(int id, int number = 1)
        {
            Ingredients[id].Number -= number;
            if (Ingredients[id].Number <= 0 && Ingredients[id].Item.Type != IngredientType.TeaLeaves)
                Ingredients.RemoveAt(id);
        }

        public void DeleteIngredient(IngredientType type, int number = 1)
        {
            DeleteIngredient(GetIngredientId(type), number);
        }
    }
}
