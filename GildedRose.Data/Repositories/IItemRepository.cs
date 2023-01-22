using GildedRose.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Data.Repositories
{
    public interface IItemRepository
    {
        ICollection<Item> GetItems();
    }
}
