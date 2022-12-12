using GildedRose.Console.Domain.Entities;
using System.Collections.Generic;

namespace GildedRose.Console.Contracts
{
    internal interface IItemRepository
    {
        /// <summary>
        /// Gets all items from a repository.
        /// </summary>
        /// <returns>All items stored in a repository.</returns>
        ICollection<Item> GetAll();

        /// <summary>
        /// Saves all items in a repository.
        /// </summary>
        /// <param name="items">Items that will be stored.</param>
        void SaveAll(ICollection<Item> items);
    }
}