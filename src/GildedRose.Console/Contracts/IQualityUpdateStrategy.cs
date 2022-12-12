using GildedRose.Console.Domain.Entities;

namespace GildedRose.Console.Contracts
{
    /// <summary>
    /// Strategy that will be applied to update an items Quality.
    /// </summary>
    internal interface IQualityUpdateStrategy
    {
        /// <summary>
        /// Name of the item for which the strategy will be applied.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Updates the items Quality.
        /// </summary>
        /// <param name="item"></param>
        void UpdateQuality(Item item);
    }
}