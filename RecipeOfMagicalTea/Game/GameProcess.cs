using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecipeOfMagicalTea
{
    [Serializable]
    public class GameProcess
    {
        ControlData ControlData { get; set; }
        public GameState GameState { get; set; }
        public string Message { get; set; }
        public DateTime MessageGenerationTime { get; set; }

        public Level Level { get; set; }

        public Hero Hero { get; set; }
        public DateTime HeroHappinessUpdateTime { get; set; }
        public int HeroNumberCanInventRecipe { get; set; }

        public List<string> Dialogs { get; set; }
        public string InformationPageText { get; set; }
        public string Help { get; set; }

        public GameProcess()
        {
            ControlData = new ControlData();

            Level = ControlData.GetLevel(0);
            Help = ControlData.GetHelp();

            Hero = new Hero(Level.StartHeroX, Level.StartHeroY, 100, 0);
            Hero.Notepad.Recipes.Add(ControlData.GetRecipe(0));
            //Hero.Inventory.Add(new ItemNumber<Thing>(1, new Thing(ThingType.Cup, "Чашка", 2, 30)));
            //Hero.Inventory.Add(new ItemNumber<Thing>(1, new Thing(ThingType.Boiler, "Старый котел", 0, 0)));
            HeroHappinessUpdateTime = DateTime.Now;
            HeroNumberCanInventRecipe = 0;

            Dialogs = new List<string>();
        }

        public void Move(int x, int y)
        {
            Hero.ChangeDirection(x, y);

            var mapPassage = Level.GetLocation().GetPassage(Hero.NextX(), Hero.NextY());
            if (mapPassage != null)
            {
                var nextMapName = mapPassage.LocationName;
                if (Level.LocationIsVillage())
                    ChangeGameState(GameState.ChangeMap);
                else
                {
                    if (Level.GetLocation(nextMapName) == null)
                        Level.Locations.Add(ControlData.GetLocation(nextMapName));
                    MoveToPassage(Level.Locations.FindIndex(t => t.Name == mapPassage.LocationName));
                }
            }
            else

            if (Level.CanGoTo(Hero.NextX(), Hero.NextY()))
                Hero.Move(x, y);
        }

        internal void ChangeMap(int locationNumber)
        {
            if (locationNumber != 0)
                MoveToPassage(locationNumber);
            ChangeGameState(GameState.Map);
        }

        public void MoveToPassage(int locationNumber)
        {
            var nextMapPassage = Level.Locations[locationNumber].Passages.First(t => t.LocationName == Level.GetLocation().Name);
            Hero.X = nextMapPassage.InX;
            Hero.Y = nextMapPassage.InY;

            Level.ThisLocationNumber = locationNumber;

            if (Level.LocationIsVillage())
                Hero.Happiness = 100;
        }

        public void Interact()
        {
            var activeObject = Level.GetLocation().ActiveObjects.FirstOrDefault(t => t.X == Hero.NextX() && (t.Y == Hero.NextY()));
            if (activeObject != null)
                SetMessage(activeObject.Interact(Hero));

            if (GetCharacterNextHero() != null)
                GameState = GameState.Communication;

            if (Level.LocationIsVillage())
            {
                if (Level.Table.X == Hero.NextX() && Level.Table.Y == Hero.NextY())

                if (HeroNumberCanInventRecipe > 0)
                {
                    Hero.Notepad.Add(Level.InventRecipes[Hero.ExperienceLevel - HeroNumberCanInventRecipe]);
                    HeroNumberCanInventRecipe--;
                    SetMessage("Вы придумали новый рецепт");
                }
                else
                    if (Level.ExperienceLevels.Count != Hero.ExperienceLevel)
                        SetMessage("Вы не можете придумать рецепт - недостаточно опыта");
                    else
                        SetMessage("Вы уже придумали достаточное количество рецептов");

                if (Level.Boiler.X == Hero.NextX() && Level.Boiler.Y == Hero.NextY())
                    GameState = GameState.Boiler;
            }
        }

        public void Update()
        {
            var activeObjects = Level.GetLocation().ActiveObjects.Where(t => (DateTime.Now - t.UpdateTime).Seconds > 30).ToList();
            if (activeObjects != null)
                activeObjects.ForEach(t => t.Update());

            if (!Level.LocationIsVillage() && GameState != GameState.Menu && (DateTime.Now - HeroHappinessUpdateTime).Seconds > 1.5)
            {
                HeroHappinessUpdateTime = DateTime.Now;
                Hero.Happiness--;
            }
            else 

            if (Hero.Happiness <= 0)
            {
                SetMessage("Уровень счастья упал до нуля. Вам пришлось вернуться в деревню чтобы отдохнуть. Вы потратили все ваше имущество на востановление сил.");
                Hero.Happiness = 100;
                Hero.Inventory.Ingredients.Clear();
                Hero.Inventory.Add(new ItemNumber<Ingredient>(0, new Ingredient(IngredientType.TeaLeaves)));
                Hero.Inventory.Things.Clear();
                Level.ThisLocationNumber = 0;
                Hero.MoveTo(Level.StartHeroX, Level.StartHeroY);
            }

            if ((DateTime.Now - MessageGenerationTime).Seconds > 1)
                Message = "";

        }

        public void UseThing(int id)
        {
            if (Hero.Inventory.Things.Count >= id + 1)
                switch(Hero.Inventory.Things[id].Item.Type)
                {
                    case ThingType.Tea:
                        if (Hero.Inventory.Things[id].Item.Name == Level.MainLevelRecipe.Recipe.Name)
                            GameState = GameState.End;
                        Hero.UseThing(id);
                        break;
                    case ThingType.Boiler:
                        GameState = GameState.Boiler;
                        break;
                }
        }

        public void BrewThing(int id)
        {
            if (Hero.Notepad.Recipes.Count >= id + 1)
                if (Hero.BrewTea(Hero.Notepad.Recipes[id]))
                {
                    Hero.Experience++;
                    if (Hero.ExperienceLevel != Level.ExperienceLevels.Count && Hero.Experience >= Level.ExperienceLevels[Hero.ExperienceLevel])
                    {
                        Hero.ExperienceLevel++;
                        HeroNumberCanInventRecipe++;
                    }
                    SetMessage("Вы сварили чай");
                }

                else
                    SetMessage("У вас нет всех необходимых ингредиентов");
        }

        public void ChoiceCommunicationType(int communicationTypeNumber)
        {
            var character = GetCharacterNextHero();
            var characterCommunicationTypes = character.CommunicationTypes[communicationTypeNumber];
            if (character.ShopThings == null)
                communicationTypeNumber += 2;
            switch (characterCommunicationTypes)
            {
                case CommunicationType.Dialog:
                    Dialogs.Add(character.Name + ":");
                    GameState = GameState.CommunicationDialog;
                    break;
                case CommunicationType.Bay:
                    GameState = GameState.CommunicationBay;
                    break;
                case CommunicationType.Sell:
                    GameState = GameState.CommunicationSell;
                    break;
                case CommunicationType.GetMainLevelRecipe:
                if (Level.InventRecipes.All(t => Hero.Inventory.Things.Any(c => c.Item.Name == t.Name)))
                {
                    Level.InventRecipes.ForEach(t => Hero.Inventory.DeleteThing(t.Name));
                    Hero.Notepad.Add(Level.MainLevelRecipe.Recipe);
                    Level.MainLevelRecipe.SuccessfullResult = true;
                }
                    InformationPageText = Level.MainLevelRecipe.GetText();
                    GameState = GameState.InformationPage;
                    break;
            }
        }

        public void ChoiceDialoglAnsver(int dialolAnsveNumber)
        {
            var character = Level.GetCharacterNextHero(Hero.NextX(), Hero.NextY());
            if (!character.Dialog.CheckEnd())
            {
                Dialogs.Add(character.Dialog.Steps[character.Dialog.CurrentStepNumber].Text);
                Dialogs.Add("-" + character.Dialog.Steps[character.Dialog.CurrentStepNumber].Ansvers[dialolAnsveNumber].Text);
                character.Dialog.SetNextStep(dialolAnsveNumber);
            }
            else
            {
                Dialogs.Add(character.Dialog.Steps[character.Dialog.CurrentStepNumber].Text);
                Dialogs.Add("\n");
                Hero.Notepad.Dilogs.AddRange(Dialogs);
                Dialogs.Clear();
                if (character.Dialog.CheckGoodResult())
                    SetMessage(character.DilogResult(Hero));
                character.Dialog.CurrentStepNumber = 0;
                character.Dialog = new Dialog(new List<DialogStep>() { new DialogStep("Здравствуйте! У меня нет для вас новостей.") });
                GameState = GameState.Communication;
            }
        }

        public void BayThing(int thingNumber)
        {
            var character = Level.GetCharacterNextHero(Hero.NextX(), Hero.NextY());
            if (character.ShopThings.Count > thingNumber)
            {
                if (character.Sell(Hero, thingNumber))
                    SetMessage("Вы совершили покупку");
                else
                    SetMessage("Вы не можете купить это");
            }
        }

        public void SellThing(int thingNumber)
        {
            if (Hero.Inventory.Things.Count > thingNumber)
            {
                if (Hero.Sell(thingNumber))
                    SetMessage("Вы совершили продажу");
            }
        }

        public void ShowHelp()
        {
            InformationPageText = Help;
            ChangeGameState(GameState.InformationPage);
        }

        //internal void HeroGoHome()
        //{
        //    if (!Level.LocationIsVillage())
        //    {
        //        Hero.MoveTo(Level.StartHeroX, Level.StartHeroY, Level.StartHeroDirection);
        //        Level.ThisLocationNumber = 0;
        //    }
        //}

        public void ChangeGameState(GameState gameState)
        {
            GameState = gameState;
        }


        public Character GetCharacterNextHero()
        {
            return Level.GetCharacterNextHero(Hero.NextX(), Hero.NextY());
        }


        public void SetMessage(string message)
        {
            Message = message;
            MessageGenerationTime = DateTime.Now;
        }
    }
}