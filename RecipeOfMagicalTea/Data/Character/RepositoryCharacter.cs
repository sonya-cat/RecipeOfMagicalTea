using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RecipeOfMagicalTea
{
    [Serializable]
    public class RepositoryCharacter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Dialog Dialog { get; set; }
        public int DialogResultThingId { get; set; }
        public int DialogResultThingNumber { get; set; }
        public int[] ShopThingIds { get; set; }

        public RepositoryCharacter()
        {
        }

        public RepositoryCharacter(int id, string name, int x, int y, Dialog dialog, int dialogResultThingId, int dialogResultThingNumber, int[] shopThingIds)
        {
            Id = id;
            Name = name;
            X = x;
            Y = y;
            Dialog = dialog;
            DialogResultThingId = dialogResultThingId;
            DialogResultThingNumber = dialogResultThingNumber;
            ShopThingIds = shopThingIds;
        }
    }
}
