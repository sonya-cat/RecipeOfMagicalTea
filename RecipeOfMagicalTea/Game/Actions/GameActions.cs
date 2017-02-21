using System;

namespace RecipeOfMagicalTea
{
    public class GameActions
    {
        MapActions MapActions { get; set; }
        InventoryActions InventoryActions { get; set; }
        CommunicationActions CommunicationActions { get; set; }
        CommunicationDialogActions CommunicationDialogActions { get; set; }
        CommunicationBayActions CommunicationBayActions { get; set; }
        CommunicationSellActions CommunicationSellActions { get; set; }
        BoilerActions BoilerActions { get; set; }
        NotepadActions NotepadActions { get; set; }
        ChangeMapActions ChangeMapActions { get; set; }
        MainLevelRecipePageAction InformationPageAction { get; set; }

        public GameActions(GameProcess gameProcess)
        {
            MapActions = new MapActions(gameProcess);
            InventoryActions = new InventoryActions(gameProcess);
            CommunicationActions = new CommunicationActions(gameProcess);
            CommunicationDialogActions = new CommunicationDialogActions(gameProcess);
            CommunicationBayActions = new CommunicationBayActions(gameProcess);
            CommunicationSellActions = new CommunicationSellActions(gameProcess);
            BoilerActions = new BoilerActions(gameProcess);
            NotepadActions = new NotepadActions(gameProcess);
            ChangeMapActions = new ChangeMapActions(gameProcess);
            InformationPageAction = new MainLevelRecipePageAction(gameProcess);
        }

        public void Action(ConsoleKeyInfo pressKey, GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Map:
                    MapActions.Action(pressKey);
                    break;
                case GameState.Inventory:
                    InventoryActions.Action(pressKey);
                    break;
                case GameState.Communication:
                    CommunicationActions.Action(pressKey);
                    break;
                case GameState.CommunicationDialog:
                    CommunicationDialogActions.Action(pressKey);
                    break;
                case GameState.CommunicationBay:
                    CommunicationBayActions.Action(pressKey);
                    break;
                case GameState.CommunicationSell:
                    CommunicationSellActions.Action(pressKey);
                    break;
                case GameState.Boiler:
                    BoilerActions.Action(pressKey);
                    break;
                case GameState.Notepad:
                    NotepadActions.Action(pressKey);
                    break;
                case GameState.ChangeMap:
                    ChangeMapActions.Action(pressKey);
                    break;
                case GameState.InformationPage:
                    InformationPageAction.Action(pressKey);
                    break;
            }
        }
    }
}