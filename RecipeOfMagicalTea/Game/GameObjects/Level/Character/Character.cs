using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RecipeOfMagicalTea
{
    public class Character
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public List<CommunicationType> CommunicationTypes { get; set; }
        public Dialog Dialog { get; set; }
        public ItemNumber<Thing> DialogGoodResultThing { get; set; }
        public List<Thing> ShopThings;

        public Character()
        {
        }
        
        public Character(string name, int x, int y, List<CommunicationType> characterCommunicationTypes, Dialog dialog, ItemNumber<Thing> dialogGoodResultThing, List<Thing> shopThings)
        {
            Name = name;
            X = x;
            Y = y;
            CommunicationTypes = characterCommunicationTypes;
            Dialog = dialog;
            DialogGoodResultThing = dialogGoodResultThing;
            ShopThings = shopThings;
        }

        public string DilogResult(Hero hero)
        {
            if (DialogGoodResultThing != null)
            {
                hero.Inventory.Add(DialogGoodResultThing);
                return "Вы получили " + DialogGoodResultThing.Item.Name + " " + DialogGoodResultThing.Number + "";
            }
            return "";
        }

        public bool Sell(Hero hero, int ThingNumber)
        {
            if (hero.Inventory.Ingredients.Find(t => t.Item.Type == IngredientType.TeaLeaves).Number >= ShopThings[ThingNumber].Cost)
            {
                hero.Inventory.Ingredients.Find(t => t.Item.Type == IngredientType.TeaLeaves).Number -= ShopThings[ThingNumber].Cost;
                hero.Inventory.Add(new ItemNumber<Thing>(1, ShopThings[ThingNumber]));
                return true;
            }
            return false;
        }
    }
}
