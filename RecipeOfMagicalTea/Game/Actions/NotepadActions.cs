using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    class NotepadActions
    {
        public NotepadActions(GameProcess gameProcess)
        {
            onClose += gameProcess.ChangeGameState;
        }

        public delegate void MethodContainerGameState(GameState gameState);
        public event MethodContainerGameState onClose;

        public void Action(ConsoleKeyInfo key)
        {
            Close(key);
        }

        private void Close(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.Q)
                onClose(GameState.Map);
        }
    }
}

