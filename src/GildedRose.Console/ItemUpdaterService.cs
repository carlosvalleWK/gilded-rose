using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console
{
    internal class ItemUpdaterService : IItemUpdaterService
    {
        public void UpdateItems(IEnumerable<Item> items)
        {
            foreach (var updater in items.Select(item => new ItemUpdater(item)))
            {
                updater.UpdateQuality();
                updater.UpdateSellIn();
            }
        }
    }
}