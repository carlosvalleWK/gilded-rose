using GildedRose.Domain.Models;

namespace GildedRose.Domain.Interfaces.Business
{
    public interface IItemGenerator
    {
        List<Item> GenerateItems();
    }
}
