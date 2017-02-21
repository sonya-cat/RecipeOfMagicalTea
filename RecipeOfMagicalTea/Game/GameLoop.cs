using RecipeOfMagicalTea.Helpers;
using System;
using System.Threading;

namespace RecipeOfMagicalTea
{
    public class GameLoop
    {
        public GameProcess GameProcess;
        GameActions GameActions;
        UserInterface UserInterface;
        int Step;

        public GameLoop(GameProcess gameProcess = null)
        {
            GameProcess = gameProcess ?? new GameProcess();
            GameActions = new GameActions(GameProcess);
            UserInterface = new UserInterface();
            Step = 120;
        }

        public void Loop()
        {
            GameProcess.GameState = GameState.Map;
            var previousGameState = GameState.Map;
            while (GameProcess.GameState != GameState.Menu && GameProcess.GameState != GameState.End)
            {
                DateTime StartTime = DateTime.Now;
                if (KeyPressHelper.PressKey)
                {
                    GameActions.Action(KeyPressHelper.Key, GameProcess.GameState);
                    KeyPressHelper.PressKey = false;
                }
                GameProcess.Update();
                if(!(GameProcess.GameState == previousGameState && GameProcess.GameState  == GameState.Notepad))
                    UserInterface.Render(GameProcess);
                previousGameState = GameProcess.GameState;
                Thread.Sleep(Step - (int)(DateTime.Now - StartTime).TotalSeconds);
            }
            if(GameProcess.GameState == GameState.End)
            {
                Console.Clear();
                Console.SetCursorPosition(70, 15);
                Console.WriteLine("Демо-версия игры пройдена!");
                Thread.Sleep(3000);
            }
        }
    }
}