using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace RecipeOfMagicalTea
{
    [Serializable]
    public class Dialog
    {
        public List<DialogStep> Steps { get; set; }
        public int CurrentStepNumber { get; set; }
        public int GoodResultLastStepNumber { get; set; }

        public Dialog()
        {
        }

        public Dialog(List<DialogStep> steps, int goodResultLastStepNumber = -1)
        {
            CurrentStepNumber = 0;
            GoodResultLastStepNumber = goodResultLastStepNumber;
            Steps = steps;
        }

        public void SetNextStep(int ansverNumber)
        {
            CurrentStepNumber = Steps[CurrentStepNumber].Ansvers[ansverNumber].NextDialogStepNumber;
        }

        public DialogStep CurrentStep()
        {
            return Steps[CurrentStepNumber];
        }

        public bool CheckEnd()
        {
            return CurrentStep().Ansvers.Count == 0;
        }

        public bool CheckGoodResult()
        {
            return GoodResultLastStepNumber == CurrentStepNumber;
        }
    }
}