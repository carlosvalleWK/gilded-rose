using GildedRose.Domain.Enums;

namespace GildedRose.Domain.Models
{
    public class Item
    {
        public string Name { get; init; } = default!;
        public int SellIn { get; set; } = default!;
        public int Quality { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public QualifyQualityType QualifyQualityType { get; init; } = default!;
    }
}