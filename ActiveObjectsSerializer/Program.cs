using RecipeOfMagicalTea;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ActiveObjectsSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            var ingredientObjects = new List<RepositoryIngredientObject>
            {
                new RepositoryIngredientObject(0, "Чайный куст", 3, new ItemNumber<Ingredient>(2, new Ingredient(IngredientType.TeaLeaves) )),
            };

            XmlSerializer serializerBushs = new XmlSerializer(typeof(List<RepositoryIngredientObject>));
            FileStream locationBushs = new FileStream("IngredientObjects.xml", FileMode.OpenOrCreate);
            serializerBushs.Serialize(locationBushs, ingredientObjects);
            locationBushs.Close();
        }
    }
}
