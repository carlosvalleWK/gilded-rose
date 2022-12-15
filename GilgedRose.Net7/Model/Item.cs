using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GilgedRose.Net7.Model
{
    internal class Item
    {
        public Item(string name, int sellIn, int quality, decimal price)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
            Price = price;
        }

        public string Name { get; init; }
        public int SellIn { get; init; }
        public int Quality { get; init; }
        public decimal Price { get; init; }
        public bool IsAgingGood { get; set; }


    }
}
