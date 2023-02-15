using GildedRose.DTO;
using System.Collections.Generic;

namespace GildedRose.Repository.Interfaces
{
    public interface IItemsRepository
    {
        IEnumerable<Item> GetAll();
        void SaveAll(IEnumerable<Item> items);
    }
}
