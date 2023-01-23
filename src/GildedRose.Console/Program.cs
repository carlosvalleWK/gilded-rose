using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        private IList<Item> _items;

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program
            {
                _items = new List<Item>
                {
                    new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                    new Item
                    {
                        Name = "Aged Brie", SellIn = 2, Quality = 0, IsInverseAging = true
                    },
                    new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 }
                }
            };

            app.UpdateQuality();

            System.Console.ReadKey();
        }

        private void UpdateQuality()
        {
            // in a most realistic app, this should be injected in D.I 
            var updaterService = new ItemUpdaterService();
            updaterService.UpdateItems(_items);
        }
    }
}