using GildedRose.Entities;
using System;

namespace GildedRose.Business.Services
{
    public abstract class GenericItemService<ItemType> where ItemType : Item
    {
        private const decimal PRICE_WEIGHT = 1.9M;

        protected abstract void UpdateQuality(ItemType item);

        public void Update(ItemType item)
        {
            UpdateQuality(item);

            item.Price = Math.Round(item.Quality * PRICE_WEIGHT, 2);
            item.SellIn--;
        }
    }
}
