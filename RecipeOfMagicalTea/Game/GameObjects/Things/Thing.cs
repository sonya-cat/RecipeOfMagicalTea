namespace RecipeOfMagicalTea
{
    public class Thing
    {
        public ThingType Type { get; set; }
        public string Name { get; set; }
        public int Effect { get; set; }
        public int Cost { get; set; }

        public Thing(ThingType type, string name, int effect, int cost)
        {
            Type = type;
            Name = name;
            Effect = effect;
            Cost = cost;
        }
    }
}
