using GildedRose.Console.Contracts;
using GildedRose.Console.Domain.Entities;

namespace GildedRose.Console.QualityUpdateStrategies
{
    internal class DefaultStrategy : IQualityUpdateStrategy
    {
        public string Name => "Default";

        public void UpdateQuality(Item item)
        {
            item.Quality -= (item.SellIn >= 0) ? 1 : 2;
        }
    }
}