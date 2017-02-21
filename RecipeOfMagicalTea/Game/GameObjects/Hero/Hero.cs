using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    public class Hero
    {
        public int X { get; set; }
        public int Y { get; set; }
        public DirectionType Direction { get; set; }

        public int Happiness { get; set; }
        public int Experience { get; set; }
        public int ExperienceLevel { get; set; }

        public Inventory Inventory { get; set; }
        public Notepad Notepad { get; set; }

        public Hero(int x, int y, int happiness, int experience)
        {
            Inventory = new Inventory();
            Notepad = new Notepad();
            Direction = DirectionType.Down;
            X = x;
            Y = y;
            Happiness = happiness;
            Experience = experience;
            ExperienceLevel = 0;
        }

        public void Move (int xMove, int yMove)
        {
            X += xMove;
            Y += yMove;
        }

        public void ChangeDirection(int x, int y)
        {
            if (x == 1)
                Direction = DirectionType.Right;
            if (x == -1)
                Direction = DirectionType.Left;
            if (y == 1)
                Direction = DirectionType.Down;
            if (y == -1)
                Direction = DirectionType.Top;
        }

        public void MoveTo(int x, int y, DirectionType directionType)
        {
            Direction = directionType;
            MoveTo(x, y);
        }

        public void MoveTo(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int NextX()
        {
            return (Direction == DirectionType.Down || Direction == DirectionType.Top) ? X :
                    Direction == DirectionType.Right ? X + 1 : X - 1;
        }

        public int NextY()
        {
            return (Direction == DirectionType.Right || Direction == DirectionType.Left) ? Y :
                    Direction == DirectionType.Down ? Y + 1 : Y - 1;
        }

        public void UseThing (int id)
        {
            switch (Inventory.Things[id].Item.Type)
            {
                case ThingType.Tea:
                    Happiness += Inventory.Things[id].Item.Effect + (Inventory.Things.Any(t => t.Item.Type == ThingType.Cup)? Inventory.Things.FirstOrDefault(t => t.Item.Type == ThingType.Cup).Item.Effect : 0);
                    Inventory.DeleteThing(id);
                    break;
            }
        }

        public bool BrewTea (Recipe recipe)
        {
            if (Inventory.CheckIngredients(recipe.Ingredients))
            {
                recipe.Ingredients.ForEach(t => Inventory.DeleteIngredient(t.Item.Type, t.Number));
                Inventory.Add(new ItemNumber<Thing>(1, new Thing(ThingType.Tea, recipe.Name, recipe.ThingEffect, recipe.ThingCost)));
                return true;
            }
            return false;
        }

        public bool Sell(int id)
        {
            if (Inventory.Things.Count > id)
            {
                AddTeaLeavs(Inventory.Things[id].Item.Cost);
                Inventory.DeleteThing(id);
                return true;
            }
            return false;
        }

        public int GetNumberOfTeaLeavs()
        {
            return Inventory.Ingredients.First(t => t.Item.Type == IngredientType.TeaLeaves).Number;
        }

        public void AddTeaLeavs(int number)
        {
            Inventory.Add(new ItemNumber<Ingredient>(number, new Ingredient(IngredientType.TeaLeaves)));
        }
    }
}
