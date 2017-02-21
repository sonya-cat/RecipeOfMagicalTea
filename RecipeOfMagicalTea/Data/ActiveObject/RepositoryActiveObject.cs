using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    [Serializable]
    public class RepositoryActiveObject
    {
        public ActiveObjectType Type { get; set; }
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public RepositoryActiveObject()
        {
        }

        public RepositoryActiveObject(ActiveObjectType type, int id, int x, int y)
        {
            Type = type;
            Id = id;
            X = x;
            Y = y;
        }
    }
}