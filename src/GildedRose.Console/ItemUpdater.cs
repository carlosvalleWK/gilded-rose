using System;

namespace GildedRose.Console
{
    internal class ItemUpdater
    {
        private const int MaxQuality = 50;
        private const int MinQuality = 0;
        private const decimal PriceConstant = 1.9M;

        private readonly Item _item;

        public ItemUpdater(Item item)
        {
            _item = item;
        }

        public void UpdateQuality()
        {
            UpdateItemQuality();
            _item.Price = Math.Round(_item.Quality * PriceConstant, 2);
        }

        private void UpdateItemQuality()
        {
            if (_item.IsInverseAging)
            {
                IncreaseQuality();
            }
            else
            {
                DecreaseQuality();
            }
        }

        public void UpdateSellIn()
        {
            DecreaseSellIn();

            if (_item.SellIn >= 0) return;

            UpdateItemQuality();
        }

        private void IncreaseQuality()
        {
            if (_item.Quality < MaxQuality)
            {
                _item.Quality++;
            }
        }

        private void DecreaseQuality()
        {
            if (_item.Quality > MinQuality)
            {
                _item.Quality--;
            }
        }

        private void DecreaseSellIn()
        {
            _item.SellIn--;
        }
    }
}