using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RecipeOfMagicalTea
{
    [Serializable]
    public class IngredientObject : IActiveObject
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int MaxIngridientNumber { get; set; }
        public ItemNumber<Ingredient> Ingredient { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool CanInteract { get; set; }

        public IngredientObject()
        {
        }

        public IngredientObject(string name, int x, int y, int maxIngridientNumber, ItemNumber<Ingredient> ingredient)
        {
            Name = name;
            X = x;
            Y = y;
            MaxIngridientNumber = maxIngridientNumber;
            Ingredient = ingredient;
            CanInteract = true;
            UpdateTime = DateTime.Now;
        }

        public string Interact(Hero hero)
        {
            if (CanInteract)
            {
                hero.Inventory.Add(new ItemNumber<Ingredient>(Ingredient.Number, Ingredient.Item));
                UpdateTime = DateTime.Now;
                CanInteract = false;
                return "Вы нашли: " + Ingredient.Item.Type.GetName() + " " + Ingredient.Number;
            }
            return "Вы ничего не нашли";
        }

        public void Update()
        {
            Ingredient.Number = Randomizer.Random.Next(1, MaxIngridientNumber);
            CanInteract = true;
        }
    }
}
