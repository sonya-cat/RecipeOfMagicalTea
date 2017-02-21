using System;

namespace RecipeOfMagicalTea
{
    public abstract class BaseAttribute : Attribute
    {
        private readonly object _value;
        public BaseAttribute(object value) { this._value = value; }

        public object GetValue() { return this._value; }
    }
}