using GildedRose.Data.Repositories;
using GildedRose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Business.Services
{
    public class ItemService : IItemService
    {
        private IItemRepository _itemRepository { get; }
        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public void UpdateItems() {
            List<Item> items = _itemRepository.GetItems().ToList();

            for (var i = 0; i < items.Count; i++)
            {
                items[i].Update();
            }
        }
    }
}
