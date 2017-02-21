using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    class BoilerActions
    {
        public BoilerActions(GameProcess gameProcess)
        {
            onBrewThing += gameProcess.BrewThing;
            onClose+= gameProcess.ChangeGameState;
        }

        public delegate void MethodContainer(int id);
        public delegate void MethodContainerGameState(GameState gameState);
        public event MethodContainer onBrewThing;
        public event MethodContainerGameState onClose;

        public void Action(ConsoleKeyInfo key)
        {
            BrewThing(key);
            Close(key);
        }

        private void Close(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.Q)
                onClose(GameState.Map);
        }

        public void BrewThing(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.D0
                || key.Key == ConsoleKey.D1
                || key.Key == ConsoleKey.D2
                || key.Key == ConsoleKey.D3
                || key.Key == ConsoleKey.D4
                || key.Key == ConsoleKey.D5
                || key.Key == ConsoleKey.D6
                || key.Key == ConsoleKey.D7
                || key.Key == ConsoleKey.D8
                || key.Key == ConsoleKey.D9)
                onBrewThing((int)(key.KeyChar -'0')-1);
        }
    }
}

