using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    [Serializable]
    public class RepositoryMainLevelRecipe
    {
        public int RecipeId { get; set; }
        public string CharacterName { get; set; }
        public string CharacteText { get; set; }
        public string CharacteTextSuccessful { get; set; }

        public RepositoryMainLevelRecipe()
        {
        }

        public RepositoryMainLevelRecipe(int recipeId, string characterName, string characteText, string characteTextSuccessful)
        {
            RecipeId = recipeId;
            CharacterName = characterName;
            CharacteText = characteText;
            CharacteTextSuccessful = characteTextSuccessful;
        }
    }
}
