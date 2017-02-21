using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    [Serializable]
    public class RepositoryRecipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ItemNumber<Ingredient>> Ingredients { get; set; }
        public int TeaId { get; set; }

        public RepositoryRecipe()
        {
        }

        public RepositoryRecipe(int id, string name, int teaId, List<ItemNumber<Ingredient>> ingredients)
        {
            Id = id;
            Name = name;
            TeaId = teaId;
            Ingredients = ingredients;
        }
    }
}
