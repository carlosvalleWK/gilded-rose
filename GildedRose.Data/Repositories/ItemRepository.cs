using GildedRose.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        public ICollection<Item> GetItems()
        {
            return new List<Item>
                {
                    new GenericItem {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new AgedItem {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new GenericItem {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7}
                };
        }
    }
}
