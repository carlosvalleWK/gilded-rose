using GildedRose.Domain.Configurations;
using GildedRose.Domain.Interfaces.Business;
using GildedRose.Domain.Models;

namespace GildedRose.Domain.Business
{
    public class QualityItems : IQualityItems
    {
        private readonly DomainConfiguration configuration;

        public QualityItems(DomainConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void CalculatePrice(Item item)
        {
            item.Price = Math.Round(item.Quality * configuration.QualifyAdjustments.Price,
                configuration.QualifyAdjustments.NumberOfDecimals);
        }

        public void DecreaseQuality(Item item, int value)
        {
            if (item.Quality > configuration.QualifyAdjustments.MinimunQuality)
                item.Quality -= value;
        }

        public void IncreaseQuality(Item item, int value)
        {
            if (item.Quality < configuration.QualifyAdjustments.MaximumQuality)
                item.Quality += value;
        }
    }
}
