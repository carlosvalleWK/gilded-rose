using GildedRose.Domain.Products.Constants;

namespace GildedRose.Domain.Products
{
    public class AgedBrieProduct : Product
    {
        public override void SetQuality()
        {
            if (Quality == ProductConstants.MaximumQuality)
            {
                return;
            }

            Quality++;

            if (Quality < ProductConstants.MaximumQuality && SellIn < ProductConstants.MinimumSellInToRecalculeQuality)
            {
                Quality++;
            }
        }
    }
}
