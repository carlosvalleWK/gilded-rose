using GildedRose.Entities;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private List<Item> Items { get; set; }

        public ItemRepository()
        {
            Items = new List<Item>
            {
                new ExpiringItem { Name = "+5 Dexterity Vest",      SellIn = 10, Quality = 20 },
                new AgingItem    { Name = "Aged Brie",              SellIn = 2,  Quality = 0  },
                new ExpiringItem { Name = "Elixir of the Mongoose", SellIn = 5,  Quality = 7  }
            };
        }

        public IEnumerable<Item> GetItems()
        {
            return Items;
        }

        public void UpdateItems(IEnumerable<Item> items)
        {
            Items = items.ToList();
        }
    }
}
