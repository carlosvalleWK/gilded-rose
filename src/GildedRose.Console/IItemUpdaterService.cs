using System.Collections.Generic;

namespace GildedRose.Console
{
    internal interface IItemUpdaterService
    {
        void UpdateItems(IEnumerable<Item> items);
    }
}