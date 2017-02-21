using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RecipeOfMagicalTea
{
    public class ControlData
    {
        List<RepositoryLevel> Levels { get; set; }
        List<RepositoryLocation> Locations { get; set; }

        List<RepositoryThing> Things { get; set; }
        List<RepositoryRecipe> Recipes { get; set; }
        List<RepositoryIngredientObject> IngredientObjects { get; set; }
        List<RepositoryCharacter> Characters { get; set; }

        public ControlData()
        {
            XmlSerializer serializerLevels = new XmlSerializer(typeof(List<RepositoryLevel>));
            FileStream levels = new FileStream("Levels .xml", FileMode.OpenOrCreate);
            Levels = (List<RepositoryLevel>)serializerLevels.Deserialize(levels);
            levels.Close();

            XmlSerializer serializerCharacters = new XmlSerializer(typeof(List<RepositoryCharacter>));
            FileStream streamCharacters = new FileStream("Characters.xml", FileMode.OpenOrCreate);
            Characters = (List<RepositoryCharacter>)serializerCharacters.Deserialize(streamCharacters);
            streamCharacters.Close();

            XmlSerializer serializerRecipes = new XmlSerializer(typeof(List<RepositoryRecipe>));
            FileStream recipes = new FileStream("Recipes.xml", FileMode.OpenOrCreate);
            Recipes = (List<RepositoryRecipe>)serializerRecipes.Deserialize(recipes);
            recipes.Close();

            XmlSerializer serializerUsableThings = new XmlSerializer(typeof(List<RepositoryThing>));
            FileStream usableThings = new FileStream("Things.xml", FileMode.OpenOrCreate);
            Things = (List<RepositoryThing>)serializerUsableThings.Deserialize(usableThings);
            usableThings.Close();

            XmlSerializer serializerIngredientObjects = new XmlSerializer(typeof(List<RepositoryIngredientObject>));
            FileStream ingredientObjects = new FileStream("IngredientObjects.xml", FileMode.OpenOrCreate);
            IngredientObjects = (List<RepositoryIngredientObject>)serializerIngredientObjects.Deserialize(ingredientObjects);
            ingredientObjects.Close();

            XmlSerializer serializerLocations = new XmlSerializer(typeof(List<RepositoryLocation>));
            FileStream locations = new FileStream("Locations.xml", FileMode.OpenOrCreate);
            Locations = (List<RepositoryLocation>)serializerLocations.Deserialize(locations);
            locations.Close();
        }

        public Recipe GetRecipe(int id)
        {
            var repositoryRecipe = Recipes.First(t => t.Id == id);
            var repositoryRecipeThing = GetThing(repositoryRecipe.TeaId);
            return new Recipe(repositoryRecipe.Name, repositoryRecipeThing.Effect, repositoryRecipeThing.Cost, repositoryRecipe.Ingredients);
        }

        public Thing GetThing(int id)
        {
            var repositoryThing = Things.First(t => t.Id == id);
            return new Thing(repositoryThing.Type, repositoryThing.Name, repositoryThing.Effect, repositoryThing.Cost);
        }

        public IActiveObject GetActiveObject(ActiveObjectType type, int id, int x, int y)
        {
            IActiveObject activeObject;
            switch (type)
            {
                case ActiveObjectType.IngredientObject:
                    var repositoryIngredientObject = IngredientObjects.First(c => c.Id == id);
                    activeObject = new IngredientObject(repositoryIngredientObject.Name, x, y, repositoryIngredientObject.MaxIngridientNumber, repositoryIngredientObject.Ingredient);
                    break;
                default:
                    activeObject = null;
                    break;
            }
            return activeObject;
        }

        public Character GetCharacter(int id)
        {
            var repositoryCharacter = Characters.FirstOrDefault(t => t.Id == id);
            var characterCommunicationTypes = new List<CommunicationType>();
            if (repositoryCharacter.Dialog != null)
                characterCommunicationTypes.Add(CommunicationType.Dialog);
            if (repositoryCharacter.ShopThingIds != null)
            {
                characterCommunicationTypes.Add(CommunicationType.Bay);
                characterCommunicationTypes.Add(CommunicationType.Sell);
            }

            return new Character(repositoryCharacter.Name, repositoryCharacter.X, repositoryCharacter.Y, characterCommunicationTypes,
                                    repositoryCharacter.Dialog, repositoryCharacter.DialogResultThingNumber != 0 ?
                                    new ItemNumber<Thing>(repositoryCharacter.DialogResultThingNumber, GetThing(repositoryCharacter.DialogResultThingId)) : null,
                                    repositoryCharacter.ShopThingIds != null ?
                                    repositoryCharacter.ShopThingIds.Select(t => GetThing(t)).ToList() : null);
        }

        public List<List<int>> GetMap(string link)
        {
            var mapStringLines = System.IO.File.ReadAllLines(link, Encoding.Default).ToList();
            var map = mapStringLines.Select(c => c.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(t => int.Parse(t)).ToList()).ToList();
            return map;
        }

        internal Location GetLocation(int id)
        {
            var repositoryLocation = Locations.FirstOrDefault(t => t.Id == id);
            return ConvertRepositoryLocationToLocation(repositoryLocation);
        }

        internal Location GetLocation(string name)
        {
            var repositoryLocation = Locations.FirstOrDefault(t => t.Name == name);
            return ConvertRepositoryLocationToLocation(repositoryLocation);
        }

        Location ConvertRepositoryLocationToLocation(RepositoryLocation repositoryLocation)
        {
            if (repositoryLocation != null)
            {
                var characters = repositoryLocation.CharacterIds != null ? repositoryLocation.CharacterIds.Select(t => GetCharacter(t)).ToList() : null;
                var activeObjects = repositoryLocation.ActiveObjects != null ? repositoryLocation.ActiveObjects.Select(t => GetActiveObject(t.Type, t.Id, t.X, t.Y)).ToList() : null;
                var map = GetMap(repositoryLocation.MapLink);
                var location = new Location(repositoryLocation.Name, map, repositoryLocation.Passages, characters, activeObjects);
                return location;
            }
            return null;
        }

        internal Level GetLevel(int id)
        {
            var repositoryLevel = Levels.FirstOrDefault(t => t.Id == id);
            var level =  new Level(id, repositoryLevel.StartHeroX, repositoryLevel.StartHeroY, repositoryLevel.StartHeroDirection,
                        repositoryLevel.LocationIds.Select(t => GetLocation(t)).ToList(), repositoryLevel.Boiler, repositoryLevel.Table,
                        new MainLevelRecipe(GetRecipe(repositoryLevel.RepositoryMainLevelRecipe.RecipeId), repositoryLevel.RepositoryMainLevelRecipe.CharacterName,
                        repositoryLevel.RepositoryMainLevelRecipe.CharacteText, repositoryLevel.RepositoryMainLevelRecipe.CharacteTextSuccessful),
                        repositoryLevel.InventRecipeIds.Select(t => GetRecipe(t)).ToList(),
                        repositoryLevel.ExperienceLevels);
            level.Locations.Find(t => t.Characters.Any(c => c.Name == level.MainLevelRecipe.CharacterName)).Characters.Find(t => t.Name == level.MainLevelRecipe.CharacterName).CommunicationTypes.Add(CommunicationType.GetMainLevelRecipe);
            return level;
        }

        public string GetHelp()
        {
            var help = System.IO.File.ReadAllText("Help.txt", Encoding.Default).ToArray();

            help[557] = '▄';
            help[607] = '☺';
            help[718] = '▼';
            help[771] = '⌂';
            return new String(help.ToArray());
        }
    }
}