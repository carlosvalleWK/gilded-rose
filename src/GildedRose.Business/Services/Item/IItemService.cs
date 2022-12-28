namespace GildedRose.Business.Services
{
    public interface IItemService<ItemType>
    {
        /// <summary>
        /// Updates the properties of specified item based on its expected sell date
        /// </summary>
        /// <param name="item">Item which properties must be updated</param>
        void Update(ItemType item);
    }
}
