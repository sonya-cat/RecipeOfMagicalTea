using RecipeOfMagicalTea;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LocationsSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            var passages1 = new List<Passage> { new Passage("Чисто-поле", 49, 10, 48, 10) };
            var activeObjects1 = new List<RepositoryActiveObject>
                                {
                                    new RepositoryActiveObject(ActiveObjectType.IngredientObject, 0, 10, 10),
                                };

            var passages2 = new List<Passage> { new Passage("Чайтаун", 0, 24, 1, 24) };
            var activeObjects2 = new List<RepositoryActiveObject>
                                {
                                    new RepositoryActiveObject(ActiveObjectType.IngredientObject, 0, 120, 20),
                                    new RepositoryActiveObject(ActiveObjectType.IngredientObject, 0, 44, 35),
                                    new RepositoryActiveObject(ActiveObjectType.IngredientObject, 0, 100, 5),
                                    new RepositoryActiveObject(ActiveObjectType.IngredientObject, 0, 58, 25),
                                    new RepositoryActiveObject(ActiveObjectType.IngredientObject, 0, 94, 21),
                                    new RepositoryActiveObject(ActiveObjectType.IngredientObject, 0, 85, 5),
                                    new RepositoryActiveObject(ActiveObjectType.IngredientObject, 0, 43, 27),
                                    new RepositoryActiveObject(ActiveObjectType.IngredientObject, 0, 72, 9),
                                    new RepositoryActiveObject(ActiveObjectType.IngredientObject, 0, 151, 43),
                                    new RepositoryActiveObject(ActiveObjectType.IngredientObject, 0, 130, 40),
                                    new RepositoryActiveObject(ActiveObjectType.IngredientObject, 0, 153, 2),
                                    new RepositoryActiveObject(ActiveObjectType.IngredientObject, 0, 11, 43)
                                };
            var listLocations = new List<RepositoryLocation>
                                {
                                    new RepositoryLocation(0, "Чайтаун", "VillagMap1.txt", passages1, new int[] { 0 }, activeObjects1),
                                    new RepositoryLocation(0, "Чисто-поле", "LocationMap1.txt", passages2, new int[] { 1 }, activeObjects2),
                                };

            XmlSerializer serializerLocations = new XmlSerializer(typeof(List<RepositoryLocation>));
            FileStream locations = new FileStream("Locations.xml", FileMode.OpenOrCreate);
            serializerLocations.Serialize(locations, listLocations);
            locations.Close();
        }
    }
}
