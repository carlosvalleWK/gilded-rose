using GildedRose.Business.Interfaces;
using GildedRose.DTO;
using GildedRose.Repository.Interfaces;
using System;

namespace GildedRose.Business
{
    public class Process : IProcess
    {
        private IItemsRepository ItemsRepository { get; set; }
        public Process(IItemsRepository itemsRepository)
        {
            ItemsRepository = itemsRepository;
        }

        public void UpdateAll()
        {
            var Items = ItemsRepository.GetAll();

            foreach (var item in Items)
            {
                ProcessItem(item);
                item.SellIn--;
                if (item.IsExpired)
                {
                    ProcessItem(item);
                }
            }
            ItemsRepository.SaveAll(Items);
        }

        private void ProcessItem(Item itm)
        {
            if (!itm.IsAgedBrie)
            {
                if (!itm.IsMinQuality)
                {
                    itm.Quality--;
                }
                else
                if (!itm.IsMaxQuality)
                {
                    itm.Quality++;
                }
            }
        }
    }
}