using System;

namespace GildedRose.Console.Domain.Entities
{
    public partial class Item
    {
        private uint quality;

        public string Name { get; private set; }

        public int SellIn { get; private set; }

        public int Quality
        {
            get => (int)quality;
            set
            {
                if (value > 50)
                {
                    quality = 50;
                    return;
                }

                if (value < 0)
                {
                    quality = 0;
                    return;
                }

                quality = (uint)value;
            }
        }

        public decimal Price { get; private set; }

        /// <summary>
        /// Reduces an items SellIn value by one.
        /// </summary>
        public void ReduceSellIn()
        {
            SellIn--;
        }

        /// <summary>
        /// Recalculates an items price based on its quality and a multiplier.
        /// </summary>
        /// <param name="priceMultiplier">Multiplier used to calculate the Prices of an item.</param>
        public void RecalculatePrice(decimal priceMultiplier)
        {
            Price = Math.Round(Quality * priceMultiplier, 2);
        }
    }
}