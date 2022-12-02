using GildedRose.Console.Data;
using GildedRose.Console.Models;
using GildedRose.Console.Services;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;
        public static IItemService _itemService;

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            _itemService = new ItemService()
            {
                Items = ItemData.GetItems()
            };

            _itemService.UpdateQuality();

            System.Console.ReadKey();
        }
    }
}
