using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    public class Menu
    {
        public void Draw (bool firstRun = false)
        {
            int x = 75;
            int y = 10;
            Console.Clear();
            Console.SetCursorPosition(x, y+=3);
            Console.WriteLine("Старт (s)");
            if (!firstRun)
            {
                Console.SetCursorPosition(x, y += 3);
                Console.WriteLine("Продолжить (c)");
            }
            Console.SetCursorPosition(x, y += 3);
            Console.WriteLine("Выйти (q)");
        }
    }
}
