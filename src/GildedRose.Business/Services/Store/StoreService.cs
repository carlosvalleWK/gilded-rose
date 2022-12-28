using GildedRose.Data.Repositories;
using GildedRose.Entities;
using System;
using System.Collections.Generic;

namespace GildedRose.Business.Services
{
    public class StoreService : IStoreService
    {
        private IItemService<AgingItem> AgingItemService { get; }
        private IItemService<ExpiringItem> ExpiringItemService { get; }
        private IItemRepository ItemRepository { get; }

        public StoreService(
            IItemService<AgingItem> agingItemService,
            IItemService<ExpiringItem> expiringItemService,
            IItemRepository itemRepository
        )
        {
            AgingItemService = agingItemService;
            ExpiringItemService = expiringItemService;
            ItemRepository = itemRepository;
        }

        public void UpdateItems()
        {
            IEnumerable<Item> items = ItemRepository.GetItems();

            foreach (Item item in items)
                switch (item)
                {
                    case AgingItem agingItem:
                        AgingItemService.Update(agingItem);
                        break;
                    case ExpiringItem expiringItem:
                        ExpiringItemService.Update(expiringItem);
                        break;
                    default:
                        throw new NotImplementedException($"Type of item [{item.GetType().FullName}] unknown");
                }

            ItemRepository.UpdateItems(items);
        }
    }
}
