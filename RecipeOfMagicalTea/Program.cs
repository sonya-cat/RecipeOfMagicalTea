using RecipeOfMagicalTea.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    class Program
    {
        static Menu Menu { get; set; }
        static MenuActions MenuActions { get; set; }
        static GameControl GameControl { get; set; }

        static void Main(string[] args)
        {
            int windowWidth = Console.LargestWindowWidth;
            int windowHeight = Console.LargestWindowHeight;

            windowsSettings(windowWidth, windowHeight);

            GameControl = new GameControl();
            MenuActions = new MenuActions(GameControl);


            Thread myThread = new Thread(KeyPressHelper.CatchKeyPress);
            myThread.Start();

            Menu = new Menu();
            Menu.Draw(true);
            bool menuLoop = true;
            while (menuLoop)
            {
                if (KeyPressHelper.PressKey)
                {
                    MenuActions.Action(KeyPressHelper.Key);
                    Menu.Draw();
                }
            }
            myThread.Abort();
        }

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);

        static void windowsSettings(int windowWidth, int windowHeight)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(windowWidth, windowHeight);
            Console.SetBufferSize(windowWidth, 1000);
            ShowWindow(GetConsoleWindow(), 3); //SW_MAXIMIZE = 3 
        }
    }
}