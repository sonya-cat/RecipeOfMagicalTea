using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    [Serializable]
    public class RepositoryLevel
    {
        public int Id { get; set; }

        public int StartHeroX { get; set; }
        public int StartHeroY { get; set; }
        public DirectionType StartHeroDirection { get; set; }

        public List<int> LocationIds { get; set; }
        public Boiler Boiler { get; set; }
        public Table Table { get; set; }

        public RepositoryMainLevelRecipe RepositoryMainLevelRecipe { get; set; }
        public List<int> InventRecipeIds { get; set; }
        public List<int> ExperienceLevels  { get; set; }

        public RepositoryLevel()
        {
        }

        public RepositoryLevel(int number, int startHeroX, int startHeroY, DirectionType startHeroDirection,
            List<int> locationIds, Boiler boiler, Table table, 
            RepositoryMainLevelRecipe repositoryMainLevelRecipe, List<int> inventRecipeIds)
        {
            Id = number;
            StartHeroX = startHeroX;
            StartHeroY = startHeroY;
            StartHeroDirection = startHeroDirection;
            LocationIds = locationIds;
            Boiler = boiler;
            Table = table;
            RepositoryMainLevelRecipe = repositoryMainLevelRecipe;
            InventRecipeIds = inventRecipeIds;
        }
    }
}
