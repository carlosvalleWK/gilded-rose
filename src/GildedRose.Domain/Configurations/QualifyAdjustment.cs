namespace GildedRose.Domain.Configurations
{
    public class QualifyAdjustment
    {
        public int MinimunSellIn { get; init; } = default!;
        public int TotalPointsDiscount { get; init; } = default!;
        public int MinimunQuality { get; init; } = default!;
        public int MaximumQuality { get; init; } = default!;
        public decimal Price { get; init; } = default!;
        public int NumberOfDecimals { get; init; } = default!;
    }
}
