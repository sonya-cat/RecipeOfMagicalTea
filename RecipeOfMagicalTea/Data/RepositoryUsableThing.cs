using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    [Serializable]
    public class RepositoryThing
    {
        public int Id { get; set; }
        public ThingType Type { get; set; }
        public string Name { get; set; }
        public int Effect { get; set; }
        public int Cost { get; set; }

        public RepositoryThing()
        {
        }

        public RepositoryThing(int id, ThingType type, string name, int effect, int cost)
        {
            Id = id;
            Type = type;
            Name = name;
            Effect = effect;
            Cost = cost;
        }
    }
}
