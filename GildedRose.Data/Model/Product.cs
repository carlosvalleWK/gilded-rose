using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Data.Model
{
    public class Product
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public decimal Price { get; set; }
        public bool IsSpecialItem { get { return this.Name.Equals("Aged Brie"); } }
        public bool IsExpired { get { return this.SellIn < 0; } }
        public override string ToString()
        {
            return $"Product: {Name} \nSellIn: {SellIn}\nQuality: {Quality}\nPrice: {Price}\n\n";
        }
    }
}
