using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea.Helpers
{
    public static class KeyPressHelper
    {
        private static bool _PressKey;
        public static bool PressKey
        {
            get
            {
                var pressKey = _PressKey;
                _PressKey = false;
                return pressKey;
            }
            set
            {
                _PressKey = value;
            }
        }
        public static ConsoleKeyInfo Key { get; set; }

        public static void CatchKeyPress()
        {
            while (true)
            {
                Key = Console.ReadKey(true);
                PressKey = true;
            }
        }
    }
}
