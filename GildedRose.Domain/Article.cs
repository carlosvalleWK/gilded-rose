using GildedRose.Domain.Common;

namespace GildedRose.Domain
{
    public class Article : BaseDomainModel
    {
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public decimal Price { get; set; }
        public bool AgedBrie { get; set; }
    }
}
