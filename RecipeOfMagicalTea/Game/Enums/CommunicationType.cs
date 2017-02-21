using RecipeOfMagicalTea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{ 
    public enum CommunicationType
    {
        [Name("Поговорить")]
        Dialog,
        [Name("Купить что-то")]
        Bay,
        [Name("Продать что-то")]
        Sell,
        [Name("Получить особый рецепт чая")]
        GetMainLevelRecipe,
    }
}
