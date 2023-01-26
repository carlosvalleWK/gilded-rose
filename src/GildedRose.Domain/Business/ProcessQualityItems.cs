using GildedRose.Domain.Configurations;
using GildedRose.Domain.Enums;
using GildedRose.Domain.Interfaces.Business;
using GildedRose.Domain.Models;

namespace GildedRose.Domain.Business
{
    public class ProcessQualityItems : IProcessQualityItems
    {
        private readonly IQualityItems qualityItems;
        private readonly DomainConfiguration configuration;

        public ProcessQualityItems(IQualityItems qualityItems, DomainConfiguration configuration)
        {
            this.qualityItems = qualityItems;
            this.configuration = configuration;
        }

        public void UpdateQuality(List<Item> items)
        {
            Parallel.ForEach(items, item =>
            {
                var totalPointsDiscount = configuration.QualifyAdjustments.TotalPointsDiscount;

                item.SellIn--;

                if (item.SellIn < configuration.QualifyAdjustments.MinimunSellIn)
                    totalPointsDiscount++;

                if (item.QualifyQualityType == QualifyQualityType.DECREASE)
                    qualityItems.DecreaseQuality(item, totalPointsDiscount);
                else
                    qualityItems.IncreaseQuality(item, totalPointsDiscount);

                qualityItems.CalculatePrice(item);
            });
        }
    }
}