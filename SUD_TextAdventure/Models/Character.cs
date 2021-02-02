using System.Collections.Generic;

namespace SUD_TextAdventure.Models
{
    public class Character
    {
        public string Name { get; set; }
        public List<Item> Inventory { get; set; }
    }

    public class Item
    {
        public string ItemName { get; set; }
    }
}