using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    public interface IActiveObject
    {
        string Name { get; set; }
        int X { get; set; }
        int Y { get; set; }
        DateTime UpdateTime { get; set; }
        void Update();
        string Interact(Hero hero);
    }
}
