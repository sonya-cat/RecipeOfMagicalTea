using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    public class MainLevelRecipe
    {
        public Recipe Recipe { get; set; }
        public string CharacterName { get; set; }
        public string CharacteText{ get; set; }
        public string CharacteTextSuccessfull { get; set; }
        public bool SuccessfullResult { get; set; }

        public MainLevelRecipe( Recipe recipe, string characterName, string characteText, string characteTextSuccessful )
        {
            Recipe = recipe;
            CharacterName = characterName;
            CharacteText = characteText;
            CharacteTextSuccessfull = characteTextSuccessful;
            SuccessfullResult = false;
        }

        public string GetText()
        {
            return SuccessfullResult ? CharacteTextSuccessfull : CharacteText;
        }
    }
}
