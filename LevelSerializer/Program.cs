using RecipeOfMagicalTea;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LevelSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainLevelRecipe = new RepositoryMainLevelRecipe(0, "Чел2", "Я пока не могу доверить вам рецепт", "Вот, держи рецепт, Дорогой!");
            var listLevels = new List<RepositoryLevel>
                        {
                            new RepositoryLevel(0, 7, 3, DirectionType.Down, new List<int> {0, 1},new Boiler(5, 3), new Table(9, 3), mainLevelRecipe, new List<int> {0})
                        };

            XmlSerializer serializerLevels = new XmlSerializer(typeof(List<RepositoryLevel>));
            FileStream levels = new FileStream("Levels .xml", FileMode.OpenOrCreate);
            serializerLevels.Serialize(levels, listLevels);
            levels.Close();
        }
    }
}
