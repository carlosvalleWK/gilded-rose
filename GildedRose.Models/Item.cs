using System;
using System.Diagnostics;

namespace GildedRose.Models
{
    public abstract class Item
    {
        private const decimal QUALITY_WEIGHTED_VALUE = 1.9M;
        private const int SCALE = 2;
        private bool isExpired 
        { 
            get
            { 
                return SellIn < 0; 
            } 
        }
        private void updateSellIn()
        {
            SellIn = SellIn - 1;
        }
        private void updatePrice()
        {
            Price = Math.Round(Quality * QUALITY_WEIGHTED_VALUE, SCALE);
        }

        protected const int MIN_QUALITY = 0;
        protected const int MAX_QUALITY = 50;
        protected abstract void updateQuality();

        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public decimal Price { get; set; }

        public void Update()
        {
            updateQuality();
            updateSellIn();
            if(isExpired) updateQuality();

            updatePrice();
        }
    }
}
