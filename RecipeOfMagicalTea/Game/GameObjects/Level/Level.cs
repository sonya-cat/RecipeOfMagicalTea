using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    public class Level
    {
        public int Number { get; set; }

        public int StartHeroX { get; set; }
        public int StartHeroY { get; set; }
        public DirectionType StartHeroDirection { get; set; }

        public List<Location> Locations { get; set; }
        public int ThisLocationNumber { get; set; }
        public Boiler Boiler { get; set; }
        public Table Table { get; set; }

        public MainLevelRecipe MainLevelRecipe { get; set; }
        public List<Recipe> InventRecipes { get; set; }
        public List<int> ExperienceLevels { get; set; }

        public Level(int number, int startHeroX, int startHeroY, DirectionType startHeroDirection, List<Location> locations,
            Boiler boiler, Table table, MainLevelRecipe mainLevelRecipe, List<Recipe> inventRecipes, List<int> experienceLevels)
        {
            Number = number;
            StartHeroX = startHeroX;
            StartHeroY = startHeroY;
            StartHeroDirection = startHeroDirection;
            Locations = locations;
            Boiler = boiler;
            Table = table;
            MainLevelRecipe = mainLevelRecipe;
            InventRecipes = inventRecipes;
            ExperienceLevels = experienceLevels;
            ThisLocationNumber = 0;
        }

        public Location GetLocation()
        {
            return Locations[ThisLocationNumber];
        }

        public bool LocationIsVillage()
        {
            return ThisLocationNumber == 0;
        }

        public bool CanGoTo(int x, int y)
        {
            var canGoTo = GetLocation().CanGoTo(x, y);
            if (ThisLocationNumber == 0)
                canGoTo = canGoTo && !(Boiler.X == x && Boiler.Y == y) && !(Table.X == x && Table.Y == y);
            return canGoTo;
        }

        public Location GetLocation(string name)
        {
            return Locations.Any(t => t.Name == name) ? Locations.First(t => t.Name == name) : null;
        }

        public Character GetCharacterNextHero(int x, int y)
        {
            var characters = GetLocation().Characters;
            return characters.FirstOrDefault(t => t.X == x && (t.Y == y));
        }
    }
}
