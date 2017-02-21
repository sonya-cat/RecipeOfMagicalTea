using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    public static class Randomizer
    {
        public static Random Random;
        static Randomizer()
        {
            Random = new Random();
        }

    }
}
