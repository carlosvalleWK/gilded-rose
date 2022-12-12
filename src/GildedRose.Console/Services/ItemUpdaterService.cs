using GildedRose.Console.Contracts;
using GildedRose.Console.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console.Services
{
    internal class ItemUpdaterService : IItemUpdater
    {        
        private readonly decimal priceMultiplier;

        private readonly ICollection<IQualityUpdateStrategy> qualityUpdateStrategies;

        public ItemUpdaterService(ICollection<IQualityUpdateStrategy> qualityUpdateStrategies, decimal priceMultiplier)
        {
            this.priceMultiplier = priceMultiplier;
            this.qualityUpdateStrategies = qualityUpdateStrategies ?? throw new ArgumentNullException(nameof(qualityUpdateStrategies));
        }

        public void Update(ICollection<Item> items)
        {
            var defaultstrategy = qualityUpdateStrategies.Single(x => x.Name == "Default");

            foreach (var item in items)
            {
                item.ReduceSellIn();

                var updateStrategy = qualityUpdateStrategies.SingleOrDefault(x => x.Name == item.Name) ?? defaultstrategy;
                updateStrategy.UpdateQuality(item);
                
                item.RecalculatePrice(priceMultiplier);
            }
        }
    }
}