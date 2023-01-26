using GildedRose.Domain.Models;

namespace GildedRose.Domain.Interfaces.Business
{
    public interface IQualityItems
    {
        void CalculatePrice(Item item);
        void DecreaseQuality(Item item, int value);
        void IncreaseQuality(Item item, int value);
    }
}
