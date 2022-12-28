namespace GildedRose.Business.Services
{
    public interface IStoreService
    {
        /// <summary>
        /// Performs a daily update of all items present in store
        /// </summary>
        void UpdateItems();
    }
}
