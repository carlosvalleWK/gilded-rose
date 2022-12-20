
namespace GildedRose.Console.Services
{
    internal class QualityIncreaseStrategy : IQualityCalculateStrategy
    {
        private const int MaxQualityValue = 50;
        public int CalculateNewQuality(int quality)
        {
            if (quality < MaxQualityValue)
            {
                return quality + 1;
            }
            return quality;
        }
    }
}
