using GildedRose.Console.Domain.Entities;
using System.Collections.Generic;

namespace GildedRose.Console.Contracts
{
    /// <summary>
    /// Service that updates all items reducing their Sellin value and adjusting the Quality and Price.
    /// </summary>
    internal interface IItemUpdater
    {
        /// <summary>
        /// Updates all items reducing their Sellin value and adjusting the Quality and Price.
        /// </summary>
        /// <param name="items">Items that will be updated</param>
        void Update(ICollection<Item> items);
    }
}