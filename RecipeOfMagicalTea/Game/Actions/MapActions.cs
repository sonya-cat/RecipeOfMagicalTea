using System;

namespace RecipeOfMagicalTea
{
    public class MapActions
    {
        public MapActions(GameProcess gameProcess)
        {
            onMove += gameProcess.Move;
            onInteract += gameProcess.Interact;
            onInventory += gameProcess.ChangeGameState;
            //onHome += gameProcess.HeroGoHome;
            onMenu += gameProcess.ChangeGameState;
            onHelp += gameProcess.ShowHelp;
        }

        public delegate void MethodContainer();
        public delegate void MethodContainerXY(int x, int y);
        public delegate void MethodContainerGameState(GameState gameState);
        public event MethodContainerXY onMove;
        public event MethodContainer onInteract;
        public event MethodContainerGameState onInventory;
        //public event MethodContainer onHome;
        public event MethodContainerGameState onMenu;
        public event MethodContainer onHelp;

        public void Action(ConsoleKeyInfo key)
        {
            MoveTop(key);
            MoveDown(key);
            MoveLeft(key);
            MoveRight(key);
            Interact(key);
            Inventory(key);
            Notepad(key);
            //Home(key);
            Menu(key);
            Help(key);
        }

        public void MoveTop(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.UpArrow)
                onMove(0,-1);
        }

        public void MoveDown(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.DownArrow)
                onMove(0, 1);
        }

        public void MoveLeft(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.LeftArrow)
                onMove(-1, 0);
        }

        public void MoveRight(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.RightArrow)
                onMove(1, 0);
        }

        public void Interact(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.Enter)
                onInteract();
        }

        public void Inventory(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.I)
                onInventory(GameState.Inventory);
        }


        public void Notepad(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.N)
                onInventory(GameState.Notepad);
        }

        //public void Home(ConsoleKeyInfo key)
        //{
        //    if (key.Key == ConsoleKey.H)
        //        onHome();
        //}

        public void Menu(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.M)
                onMenu(GameState.Menu);
        }

        public void Help(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.H)
                onHelp();
        }
    }
}