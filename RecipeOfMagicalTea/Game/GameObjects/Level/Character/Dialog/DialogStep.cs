using System;
using System.Collections.Generic;

namespace RecipeOfMagicalTea
{
    [Serializable]
    public class DialogStep
    {
        public string Text;
        public List<Ansver> Ansvers;

        public DialogStep()
        {
        }

        public DialogStep(string text, List<Ansver> ansvers = null)
        {
            Text = text;
            Ansvers = ansvers ?? new List<Ansver>();
        }
    }
}