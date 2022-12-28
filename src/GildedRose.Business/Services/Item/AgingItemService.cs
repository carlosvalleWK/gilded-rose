using GildedRose.Entities;

namespace GildedRose.Business.Services
{
    public class AgingItemService : GenericItemService<AgingItem>, IItemService<AgingItem>
    {
        private const int MAX_QUALITY = 50;
        protected override void UpdateQuality(AgingItem item)
        {
            if (item.SellIn >= 0)
                item.Quality += 1;
            else
                item.Quality += 2;

            if (item.Quality > MAX_QUALITY)
                item.Quality = MAX_QUALITY;
        }
    }
}
