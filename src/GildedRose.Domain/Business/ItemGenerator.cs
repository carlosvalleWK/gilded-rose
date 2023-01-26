using GildedRose.Domain.Enums;
using GildedRose.Domain.Interfaces.Business;
using GildedRose.Domain.Models;

namespace GildedRose.Domain.Business
{
    public class ItemGenerator : IItemGenerator
    {
        public List<Item> GenerateItems()
        {
            return new List<Item>
            {
                new() { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20, QualifyQualityType = QualifyQualityType.DECREASE},
                new() { Name = "Aged Brie", SellIn = 2, Quality = 0, QualifyQualityType = QualifyQualityType.INCREASE },
                new() { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7, QualifyQualityType = QualifyQualityType.DECREASE }
            };
        }
    }
}