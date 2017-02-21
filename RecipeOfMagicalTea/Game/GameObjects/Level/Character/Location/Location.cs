using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RecipeOfMagicalTea
{
    public class Location
    {
        public string Name { get; set; }
        public List<List<int>> Map { get; set; }
        public List<Passage> Passages { get; set; }
        public List<Character> Characters { get; set; }
        public List<IActiveObject> ActiveObjects { get; set; }

        public Location(string name, List<List<int>> map, List<Passage> passages, List<Character> characters, List<IActiveObject> activeObjects)
        {
            Name = name;
            Map = map;
            Passages = passages;
            Characters = characters ?? new List<Character>();
            ActiveObjects = activeObjects ?? new List<IActiveObject>();
        }

        public bool CanGoTo(int x, int y)
        {
            return (x >= 0 && Map[0].Count > x 
                    && y >= 0 && Map.Count > y
                    && Map[y][x] != (int)MapTypes.Wall && Map[y][x] != (int)MapTypes.Plant
                    && !ActiveObjects.Any(t => t.X == x && t.Y == y)
                    && !Characters.Any(t => t.X == x && t.Y == y));
        }

        public bool CheckPassagePosition(int x, int y)
        {
            return Passages.Any(t => t.OutX == x && t.OutY == y);
        }

        public Passage GetPassage(int x, int y)
        {
            return Passages.LastOrDefault(t => t.OutX == x && t.OutY == y);
        }
    }
}
