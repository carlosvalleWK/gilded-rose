using System;

namespace GildedRose.Console.Models
{
    public class Item
    {
        #region Private constants
        private const string AGED_BRIE = "Aged Brie";
        private const int MAX_QUALITY = 50;
        private const int MIN_QUALITY = 0;
        private const decimal PRICE_FACTOR = 1.9M;



        #endregion

        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public decimal Price { get; set; }

        #region Public Methods

        /// <summary>
        /// Recalculate price
        /// </summary>
        public void RecalculatePrice() => Price = Math.Round(Quality * PRICE_FACTOR, 2);

        /// <summary>
        /// Check if item name is "Aged Brie"
        /// </summary>
        /// <returns></returns>
        public bool IsAgedBrie() => Name == AGED_BRIE;

        /// <summary>
        /// Check if SellIn is Negative
        /// </summary>
        /// <returns></returns>
        public bool IsSellInNegative() => SellIn < 0;

        /// <summary>
        /// Decrease SellIn by one
        /// </summary>
        public void DecreaseSellIn() => SellIn--;

        /// <summary>
        /// Increase Quality if is lower than MAX_QUALITY
        /// </summary>
        public void IncreaseQuality()
        {
            if (Quality < MAX_QUALITY)
            {
                Quality = IsSellInNegative() && Quality <= (MAX_QUALITY - 2) ? Quality + 2 : Quality + 1;
            }
        }

        /// <summary>
        /// Decrease Quality if is higher than 0
        /// </summary>
        public void DecreaseQuality()
        {
            if (Quality > MIN_QUALITY)
            {
                Quality = IsSellInNegative() && Quality >= (MIN_QUALITY + 2) ? Quality - 2 : Quality - 1;
            }
        }

        #endregion
    }
}
