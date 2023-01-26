using GildedRose.Domain.Models;

namespace GildedRose.Domain.Interfaces.Business
{
    public interface IProcessQualityItems
    {
        void UpdateQuality(List<Item> items);
    }
}
