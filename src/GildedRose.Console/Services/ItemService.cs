using GildedRose.Console.Models;
using System.Collections.Generic;

namespace GildedRose.Console.Services
{
    public class ItemService : IItemService
    {
        public IList<Item> Items;

        public ItemService()
        {

        }

        /// <summary>
        /// Update Items Quality and SellIn
        /// </summary>
        public void UpdateQuality()
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
