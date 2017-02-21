using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeOfMagicalTea
{
    public class UserInterface
    {
        public void Render(GameProcess gameProcess)
        {
            switch (gameProcess.GameState)
            {
            case GameState.Map:
                RenderMap(gameProcess);
                break;
            case GameState.Inventory:
                RenderInventory(gameProcess.Hero.Inventory);
                break;
            case GameState.Communication:
                RenderCommunication(gameProcess);
                break;
            case GameState.CommunicationDialog:
                RenderCommunicationDialog(gameProcess.GetCharacterNextHero().Dialog);
                break;
            case GameState.CommunicationBay:
                RenderBay(gameProcess.GetCharacterNextHero().ShopThings, gameProcess.Hero.GetNumberOfTeaLeavs());
                break;
            case GameState.CommunicationSell:
                RenderSell(gameProcess.Hero.Inventory.Things, gameProcess.Hero.GetNumberOfTeaLeavs());
                break;
            case GameState.Boiler:
                RenderBoiler(gameProcess.Hero.Notepad.Recipes, gameProcess.Hero.Inventory.Ingredients);
                break;
            case GameState.Notepad:
                RenderNotepad(gameProcess.Hero.Notepad);
                break;
            case GameState.ChangeMap:
                RenderChangeMap(gameProcess);
                break;
            case GameState.InformationPage:
                RenderInformationPage(gameProcess.InformationPageText);
                break;
            }
            Console.SetCursorPosition(0, 54);
            Console.WriteLine(gameProcess.Message);
        }

        public void RenderMap(GameProcess gameProcess)
        {
            var thisLocation = gameProcess.Level.GetLocation();
            var thisMap = thisLocation.Map.Select(t => t.Select(c => c).ToList()).ToList();

            foreach (var character in thisLocation.Characters)
                thisMap[character.Y][character.X] = 99;

            foreach (var activeObject in thisLocation.ActiveObjects)
                switch (activeObject.Name)
                {
                    case "Чайный куст":
                        thisMap[activeObject.Y][activeObject.X] = 21;
                        break;
                    case "Лимонное дерево":
                        thisMap[activeObject.Y][activeObject.X] = 22;
                        break;
                    case "Апельсиновое дерево":
                        thisMap[activeObject.Y][activeObject.X] = 23;
                        break;
                    case "Куст клюквы":
                        thisMap[activeObject.Y][activeObject.X] = 24;
                        break;
                    case "Дерево корицы":
                        thisMap[activeObject.Y][activeObject.X] = 25;
                        break;
                    case "Куст имбиря":
                        thisMap[activeObject.Y][activeObject.X] = 26;
                        break;
                    case "Улей":
                        thisMap[activeObject.Y][activeObject.X] = 27;
                        break;
                }


            if (gameProcess.Level.ThisLocationNumber == 0)
            {
                var boiler = gameProcess.Level.Boiler;
                thisMap[boiler.Y][boiler.X] = 10;
                var table = gameProcess.Level.Table;
                thisMap[table.Y][table.X] = 11;
            }

            var hero = gameProcess.Hero;
            if (hero.Direction == DirectionType.Right)
                thisMap[hero.Y][hero.X] = 100;
            if (hero.Direction == DirectionType.Left)
                thisMap[hero.Y][hero.X] = 101;
            if (hero.Direction == DirectionType.Top)
                thisMap[hero.Y][hero.X] = 102;
            if (hero.Direction == DirectionType.Down)
                thisMap[hero.Y][hero.X] = 103;


            List<string> bufferString = new List<string>();
            for (var i = 0; i < thisMap.Count; i++)
            {
                char[] temp = new char[thisMap[0].Count];
                for (var j = 0; j < thisMap[0].Count; j++)
                    switch (thisMap[i][j])
                    {

                        case (int)MapTypes.Grass:
                            temp[j] = '·';
                            break;                           
                        case (int)MapTypes.Floor:
                            temp[j] = ' ';
                            break;
                        case (int)MapTypes.Wall:
                            temp[j] = '░';
                            break;
                        case (int)MapTypes.Plant:                        
                            temp[j] = '+';
                            break;
                        case 10:
                            temp[j] = 'o';
                            break;
                        case 11:
                            temp[j] = '▄';
                            break;

                        case 21:
                            temp[j] = '*';
                            break;
                        case 22:
                            temp[j] = '▼';
                            break;
                        case 23:
                            temp[j] = '▼';
                            break;
                        case 24:
                            temp[j] = '*';
                            break;
                        case 25:
                            temp[j] = '▼';
                            break;
                        case 26:
                            temp[j] = '*';
                            break;
                        case 27:
                            temp[j] = '⌂';
                            break;

                        case 99:
                            temp[j] = '☺';
                            break;
                        case 100:
                            temp[j] = '→';
                            break;
                        case 101:
                            temp[j] = '←';
                            break;
                        case 102:
                            temp[j] = '↑';
                            break;
                        case 103:
                            temp[j] = '↓';
                            break;
                    }
                bufferString.Add(new string(temp));
            }

            Console.Clear();
            Console.Write("Меню(M)       ");
            Console.Write("Помощь(H)       ");
            Console.Write("Инвентарь(I)       ");
            Console.Write("Блокнот(N)       ");
            Console.WriteLine("Взаимодействовать(Enter)       ");

            for (var i = 0; i < bufferString.Count; i++)
            {
                Console.WriteLine("  " + bufferString[i]);
            }
            Console.WriteLine("\n Локация: " + thisLocation.Name);
            Console.WriteLine(" Счастье: " + hero.Happiness);
            //Console.WriteLine(" " + IngredientType.TeaLeaves.GetName() + ": " + (hero.Inventory.Ingredients.Any(t => t.Item.Type == IngredientType.TeaLeaves) ? hero.Inventory.Ingredients.Find(t => t.Item.Type == IngredientType.TeaLeaves).Number : 0));
            Console.WriteLine(" Опыт: " + hero.Experience + " / " + (hero.ExperienceLevel != gameProcess.Level.ExperienceLevels.Count ? gameProcess.Level.ExperienceLevels[hero.ExperienceLevel].ToString() : "Максимальный уровень") + " (Доступно " + gameProcess.HeroNumberCanInventRecipe + " новых рецептов)");


        }

        public void RenderInventory(Inventory inventory)
        {
            Console.Clear();
            Console.WriteLine("Инвентарь:\n");
            Console.WriteLine("----------------------------\n");
            ShowThings(inventory.Things);
            ShowIngredients(inventory.Ingredients);
            Console.WriteLine("\n----------------------------");
            Console.WriteLine("\nЗакрыть(Q)");
        }

        public void RenderCommunication(GameProcess gameProcess)
        {
            var character = gameProcess.GetCharacterNextHero();
            Console.Clear();
            Console.WriteLine(character.Name + ":");
            Console.WriteLine();
            int i = 1;
            foreach(var characterCommunicationType in character.CommunicationTypes)
                Console.WriteLine(i++ + ". " + characterCommunicationType.GetName());
            Console.WriteLine("\nУйти(Q)");
        }

        public void RenderCommunicationDialog(Dialog dialog)
        {
            Console.Clear();
            Console.WriteLine(dialog.CurrentStep().Text);
            Console.WriteLine();
            for (int i = 0; i < dialog.CurrentStep().Ansvers.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + dialog.CurrentStep().Ansvers[i].Text);
            }
            if (dialog.CurrentStep().Ansvers.Count == 0)
                Console.WriteLine(1 + ". (Попрощаться)");
        }

        public void RenderBay(List<Thing> things, int teaLeavs)
        {
            Console.Clear();
            Console.WriteLine("У вас есть " + teaLeavs  + " листьев чая\n");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("\nКупить:\n");
            for (int i = 0; i < things.Count; i++)
            {
                switch (things[i].Type)
                {
                    case ThingType.Boiler:
                        Console.WriteLine(i + 1 + ". " + things[i].Name + " (позволяет варить чай в любом месте)");
                        break;
                    case ThingType.Cup:
                        Console.WriteLine(i + 1 + ". " + things[i].Name + " (дополнительные +2 к счастью при выпивании чая)");
                        break;
                    case ThingType.Tea:
                        Console.WriteLine(i + 1 + ". " + things[i].Name + " (эффект чая: + " + things[i].Effect + " к счастью)");
                        break;
                }
                Console.WriteLine("Стоимость: " + things[i].Cost + " листьев чая\n");
            }
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("\nВернуться(Q)");
        }

        public void RenderSell(List<ItemNumber<Thing>> things, int teaLeavs)
        {
            Console.Clear();
            Console.WriteLine("У вас есть " + teaLeavs + " листьев чая\n");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("\nПродать:\n");
            for (int i = 0; i < things.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + things[i].Item.Name + ", количество: " + things[i].Number);
                Console.WriteLine("Стоимость: " + things[i].Item.Cost + " листьев чая\n");
            }
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("\nВернуться(Q)");
        }

        private void RenderBoiler(List<Recipe> recipes, List<ItemNumber<Ingredient>> ingredients)
        {
            Console.Clear();
            Console.WriteLine("Выбор рецепта для варки чая:\n");
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + recipes[i].Name + " (" + recipes[i].ThingEffect + "):");
                ShowIngredients(recipes[i].Ingredients);
                Console.WriteLine();
            }
            Console.WriteLine("----------------------------");
            Console.WriteLine("\nИмеются ингридиенты:");
            ShowIngredients(ingredients);
            Console.WriteLine("\n----------------------------");
            Console.WriteLine("\nЗакрыть(Q)");
        }

        private void RenderNotepad(Notepad notepad)
        {
            Console.Clear();
            Console.WriteLine("БЛОКНОТ");
            Console.WriteLine("\n--------------------------------------------------------\n");
            Console.WriteLine("Диалоги:\n\n");
            for (int i = 0; i < notepad.Dilogs.Count; i++)
                Console.WriteLine(notepad.Dilogs[i]);

            Console.WriteLine("--------------------------------------------------------\n");
            Console.WriteLine("Рецепты:");
            Console.WriteLine();
            for (int i = 0; i < notepad.Recipes.Count; i++)
            {
                Console.WriteLine(notepad.Recipes[i].Name + ":");
                ShowIngredients(notepad.Recipes[i].Ingredients);
                Console.WriteLine("(эффект чая: + " + notepad.Recipes[i].ThingEffect + " к счастью, стоимость: " + notepad.Recipes[i].ThingCost + ")");
                Console.WriteLine();
            }
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("\nЗакрыть(Q)");
        }

        private void RenderChangeMap(GameProcess gameProcess)
        {
            Console.Clear();
            Console.WriteLine("Выберите локацию:");

            for (int i = 0; i < gameProcess.Level.Locations.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + gameProcess.Level.Locations[i].Name);
            }
            Console.WriteLine("\nЗакрыть(Q)");
        }

        private void RenderInformationPage(string text)
        {
            Console.Clear();
            Console.WriteLine(text);
            Console.WriteLine("\nЗакрыть(Q)");
        }

        private void ShowIngredients(List<ItemNumber<Ingredient>> ingredients)
        {
            foreach (var ingredient in ingredients)
                Console.WriteLine(ingredient.Item.Type.GetName() + " " + ingredient.Number);
        }

        private void ShowThings(List<ItemNumber<Thing>> things)
        {
            for (int i = 0; i < things.Count; i++)
                switch (things[i].Item.Type)
                {
                    case ThingType.Boiler:
                        Console.WriteLine(i + 1 + ". " + things[i].Item.Name + " " + things[i].Number + " (позволяет варить чай в любом месте)");
                        break;
                    case ThingType.Cup:
                        Console.WriteLine(i + 1 + ". " + things[i].Item.Name + " " + things[i].Number + " (дополнительные +2 к счастью при выпивании чая)");
                        break;
                    case ThingType.Tea:
                        Console.WriteLine(i + 1 + ". " + things[i].Item.Name + " " + things[i].Number + " (эффект чая: + " + things[i].Item.Effect + " к счастью)");
                        break;
                }

        }
    }
}