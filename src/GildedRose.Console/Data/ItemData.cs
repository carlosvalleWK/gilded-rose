using GildedRose.Console.Models;
using System.Collections.Generic;

namespace GildedRose.Console.Data
{
    public static class ItemData
    {
        /// <summary>
        /// Get Item Data
        /// </summary>
        /// <returns>Item List</returns>
        public static List<Item> GetItems()
        {
            return new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7}
                };
        }

    }
}
