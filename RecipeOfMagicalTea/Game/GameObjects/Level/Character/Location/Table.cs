using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    [Serializable]
    public class Table
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Table()
        {
        }

        public Table(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
