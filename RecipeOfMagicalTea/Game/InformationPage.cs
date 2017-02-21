using RecipeOfMagicalTea.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    public class InformationPage
    {
        public void DrawIntroduction()
        {
            var textLines = System.IO.File.ReadAllLines("Introduction.txt", Encoding.Default).ToList();
            Console.Clear();
            foreach (var textLine in textLines)
            {
                foreach (var textSymbol in textLine)
                {
                    Console.Write(textSymbol);
                    Thread.Sleep(30);
                }
                Console.Write("\n");
            }
            while (!KeyPressHelper.PressKey)
            { }
        }
    }
}
