using System;

namespace RecipeOfMagicalTea
{
    [Serializable]
    public class Ansver
    {
        public string Text;
        public int NextDialogStepNumber;

        public Ansver()
        {
        }

        public Ansver(string text, int nextDialogStepNumber)
        {
            Text = text;
            NextDialogStepNumber = nextDialogStepNumber;
        }
    }
}