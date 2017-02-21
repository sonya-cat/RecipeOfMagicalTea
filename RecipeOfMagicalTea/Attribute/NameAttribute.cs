using System;

namespace RecipeOfMagicalTea
{
    internal class Name : BaseAttribute { public Name(string value) : base(value) { } }

    public static class EnumExtensionMethods
    {
        public static string GetName(this Enum enumItem)
        {
            return enumItem.GetAttributeValue(typeof(Name), "Имя не задано");
        }
    }
}