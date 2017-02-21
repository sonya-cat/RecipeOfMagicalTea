using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    [Serializable]
    public class ItemNumber<T>
    {
        public int Number { get; set; }
        public T Item { get; set; }

        public ItemNumber()
        {
        }

        public ItemNumber(int number, T item)
        {
            Number = number;
            Item = item;
        }
    }
}
