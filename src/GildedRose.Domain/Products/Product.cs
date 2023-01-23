using GildedRose.Domain.Products.Constants;

namespace GildedRose.Domain.Products
{
    public class Product
    {
        public string Name { get; set; } = string.Empty;
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public decimal Price { get; set; }

        public void SetSellIn()
        {
            SellIn--;
        }

        public void SetPrice()
        {
            Price = Math.Round(Quality * ProductConstants.Multiplier, ProductConstants.Rounder);
        }

        public virtual void SetQuality()
        {
            if (Quality == ProductConstants.MinimumQuality)
            {
                return;
            }

            Quality--;

            if (Quality > ProductConstants.MinimumQuality && SellIn < ProductConstants.MinimumSellInToRecalculeQuality)
            {
                Quality--;
            }
        }
    }
}
