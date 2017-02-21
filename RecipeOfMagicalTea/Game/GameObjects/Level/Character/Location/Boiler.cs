using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    [Serializable]
    public class Boiler 
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Boiler()
        {
        }

        public Boiler(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
