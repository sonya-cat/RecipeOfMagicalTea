using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    [Serializable]
    public class Passage
    {
        public string LocationName { get; set; }
        public int OutX { get; set; }
        public int OutY { get; set; }
        public int InX { get; set; }
        public int InY { get; set; }

        public Passage()
        {
        }

        public Passage(string locationName, int outX, int outY, int inX, int inY)
        {
            LocationName = locationName;
            OutX = outX;
            OutY = outY;
            InX = inX;
            InY = inY;
        }
    }
}
