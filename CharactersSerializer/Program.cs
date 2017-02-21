using RecipeOfMagicalTea;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CharactersSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            var dilog = new Dialog(new List<DialogStep> {
                    new DialogStep("Здравствуй друг, угостить тебя чаем?", new List<Ansver> { new Ansver("Да!",1), new Ansver("Нет, спасибо...",2)}),
                    new DialogStep("Держи!", new List<Ansver>()),
                    new DialogStep("Очень жаль...", new List<Ansver>())}, 1);

            var characters1 = new RepositoryCharacter(0, "Чел", 20, 10, dilog, 0, 1, new int[] { 0, 1, 2 });
            var characters2 = new RepositoryCharacter(1, "Чел2", 132, 24, dilog, 0, 1, new int[] { 0, 1, 2 });

            List<RepositoryCharacter> characters = new List<RepositoryCharacter> { characters1, characters2 };

            XmlSerializer serializerCharacters = new XmlSerializer(typeof(List<RepositoryCharacter>));
            FileStream streamCharacters = new FileStream("Characters.xml", FileMode.OpenOrCreate);
            serializerCharacters.Serialize(streamCharacters, characters);
            streamCharacters.Close();
        }
    }
}
