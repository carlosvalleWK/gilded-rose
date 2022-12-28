using GildedRose.Entities;

namespace GildedRose.Business.Services
{
    public class ExpiringItemService : GenericItemService<ExpiringItem>, IItemService<ExpiringItem>
    {
        private const int MIN_QUALITY = 0;
        protected override void UpdateQuality(ExpiringItem item)
        {
            if (item.SellIn >= 0)
                item.Quality -= 1;
            else
                item.Quality -= 2;

            if (item.Quality < MIN_QUALITY)
                item.Quality = MIN_QUALITY;
        }
    }
}
