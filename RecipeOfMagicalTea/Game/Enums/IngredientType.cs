using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    public enum IngredientType
    {
        [Name("Листья чая")]
        TeaLeaves,
        [Name("Мята")]
        Mint,
        [Name("Лимон")]
        Lemon,
        [Name("Апельсин")]
        Orange,
        [Name("Грейпфрут")]
        Grapefruit,
        [Name("Лайм")]
        Lime,
        [Name("Клюква")]
        Cranberry,
        [Name("Корица")]
        Cinnamon,
        [Name("Мед")]
        Honey,
        [Name("Имбирь")]
        Ginger,
    }
}
