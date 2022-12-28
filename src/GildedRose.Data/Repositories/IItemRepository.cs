using GildedRose.Entities;
using System.Collections.Generic;

namespace GildedRose.Data.Repositories
{
    public interface IItemRepository
    {
        /// <summary>
        /// Retrieves all available items
        /// </summary>
        /// <returns>Complete set of all items</returns>
        IEnumerable<Item> GetItems();

        /// <summary>
        /// Updates items in the store
        /// </summary>
        /// <param name="items">Set of items to be updated</param>
        void UpdateItems(IEnumerable<Item> items);
    }
}
