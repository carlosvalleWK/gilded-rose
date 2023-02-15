using GildedRose.DTO;
using GildedRose.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Repository
{
    public class ItemsRepository : IItemsRepository
    {
        private IEnumerable<Item> _items { get; set; } = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7}
                };

        public IEnumerable<Item> GetAll()
        {
            return _items;
        }

        public void SaveAll(IEnumerable<Item> items)
        {
            _items = items;
        }
    }
}
