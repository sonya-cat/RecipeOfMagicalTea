using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    [Serializable]
    public class RepositoryLocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MapLink { get; set; }
        public List<Passage> Passages { get; set; }
        public int[] CharacterIds { get; set; }
        public List<RepositoryActiveObject> ActiveObjects { get; set; }


        public RepositoryLocation()
        {
        }

        public RepositoryLocation(int id, string name, string mapLink, List<Passage> passages, int[] characterIds, List<RepositoryActiveObject> activeObjects)
        {
            Id = id;
            Name = name;
            MapLink = mapLink;
            Passages = passages;
            CharacterIds = characterIds;
            ActiveObjects = activeObjects;
        }
    }
}
