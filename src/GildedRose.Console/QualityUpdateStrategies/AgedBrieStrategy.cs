using GildedRose.Console.Contracts;
using GildedRose.Console.Domain.Entities;

namespace GildedRose.Console.QualityUpdateStrategies
{
    internal class AgedBrieStrategy : IQualityUpdateStrategy
    {
        public string Name => "Aged Brie";

        public void UpdateQuality(Item item)
        {
            item.Quality += (item.SellIn >= 0) ? 1 : 2;
        }
    }
}