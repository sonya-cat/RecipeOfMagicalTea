using System;

namespace RecipeOfMagicalTea
{
    public class MenuActions
    {
        public delegate void MethodContainer();
        public event MethodContainer onStart;
        public event MethodContainer onContinue;
        //public event MethodContainer onLoad;
        //public event MethodContainer onSave;
        //public event MethodContainer onAbout;
        public event MethodContainer onExite;

        public MenuActions(GameControl gameControl)
        {
            onStart += gameControl.Start;
            onContinue += gameControl.Continue;
            //onLoad += gameControl.Load;
            //onSave += gameControl.Save;
            //onAbout += gameControl.About;
            onExite += gameControl.Exite;
        }

        public void Action(ConsoleKeyInfo key)
        {
            Start(key);
            Continue(key);
            //Save(key);
            //Load(key);
            //About(key);
            Exite(key);
        }

        public void Start(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.S)
                onStart();
        }

        public void Continue(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.C)
                onContinue();
        }
        //public void Load(ConsoleKeyInfo key)
        //{
        //    if (key.Key == ConsoleKey.L)
        //        onLoad();
        //}

        //public void Save(ConsoleKeyInfo key)
        //{
        //    if (key.Key == ConsoleKey.V)
        //        onSave();
        //}

        //public void About(ConsoleKeyInfo key)
        //{
        //    if (key.Key == ConsoleKey.A)
        //        onAbout();
        //}

        public void Exite(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.Q)
                onExite();
        }
    }
}