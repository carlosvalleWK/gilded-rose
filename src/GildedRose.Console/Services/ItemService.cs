using GildedRose.Console.Models;
using System.Collections.Generic;

namespace GildedRose.Console.Services
{
    public class ItemService : IItemService
    {
        public IList<Item> Items;

        /// <summary>
        /// Item service constructor
        /// </summary>
        public ItemService()
        {

        }

        /// <summary>
        /// Update Items properties
        /// </summary>
        public void UpdateItems()
        {
            foreach (var item in Items)
            {
                item.DecreaseSellIn();


                if (item.IsAgedBrie())
                {
                    item.IncreaseQuality();
                }
                else
                {
                    item.DecreaseQuality();
                }


                item.RecalculatePrice();
            }
        }

    }
}
