
namespace GildedRose.Console.QualityUpdateStrategy
{
    internal class QualityIncreaseStrategy : IQualityUpdateStrategy
    {
        private const int MaxQualityValue = 50;
        public void UpdateQuality(Item item)
        {
            if (item.Quality < MaxQualityValue)
            {
                item.Quality += (item.SellIn >= 0) ? 1 : 2;
            }
        }
    }
}
